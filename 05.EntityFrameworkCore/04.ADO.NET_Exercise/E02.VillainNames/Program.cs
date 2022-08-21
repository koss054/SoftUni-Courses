namespace E02.VillainNames
{
    using System;
    using System.Text;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection 
                = new SqlConnection(Config.ConnectionString);

            //int enteredId
            //    = int.Parse(Console.ReadLine());

            sqlConnection.Open();


            //string result = GetVillainNamesWithMinionsCount(sqlConnection);                               --Problem 2

            //string result = GetVillainWithMinions(sqlConnection, enteredId);                              --Problem 3

            //string[] minionInfo = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //string minionName = minionInfo[1];
            //int minionAge = int.Parse(minionInfo[2]);
            //string townName = minionInfo[3];

            //string villainName = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    [1];

            //string result = AddMinion(sqlConnection, townName, villainName, minionName, minionAge);       --Problem 4

            //string countryName = Console.ReadLine();
            //string result = ChangeTownNameCasing(sqlConnection, countryName);                             --Problem 5

            //int villainId = int.Parse(Console.ReadLine());
            //string result = RemoveVillain(sqlConnection, villainId);                                      --Problem 6

            int minionId = int.Parse(Console.ReadLine());
            string result = IncreaseMinionAge(sqlConnection, minionId);
            Console.WriteLine(result);

            sqlConnection.Close();
        }

        //Problem 2
        private static string GetVillainNamesWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder output
                = new StringBuilder();

            string query = @"  SELECT [v].[Name]
                                    , COUNT([mv].[MinionId]) AS [MinionsCount]
                                 FROM [MinionsVillains] AS [mv]
                                 JOIN [Villains] AS [v]
                                   ON [v].[Id] = [mv].VillainId
                             GROUP BY [v].[Id], [v].[Name]
                               HAVING COUNT([mv].[MinionId]) > 3
                             ORDER BY COUNT([mv].[MinionId])";

            SqlCommand cmd 
                = new SqlCommand(query, sqlConnection);

            using SqlDataReader reader
                = cmd.ExecuteReader();

            while (reader.Read())
            {
                output
                    .AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return output
                .ToString().TrimEnd();
        }

        //Problem 3
        private static string GetVillainWithMinions(SqlConnection sqlConnection, int enteredId)
        {
            StringBuilder output = new StringBuilder();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @VillainId";

            using SqlCommand getVillainNameCmd 
                = new SqlCommand(villainNameQuery, sqlConnection);

            getVillainNameCmd
                .Parameters.AddWithValue("@VillainId", enteredId);

            string villainName = (string)getVillainNameCmd.ExecuteScalar();

            if (villainName == null)
            {
                return $"No villain with ID {enteredId} exists in the database.";
            }

            output.AppendLine($"Villain: {villainName}");

            string minionsQuery = @"   SELECT [m].[Name]
                                            , [m].[Age]
                                         FROM [MinionsVillains] AS [mv]
                                    LEFT JOIN [Minions] AS [m]
                                           ON [m].[Id] = [mv].[MinionId]
	                                    WHERE [mv].VillainId = @VillainId
                                     ORDER BY [m].[Name]";

            using SqlCommand getMinionsCmd
                = new SqlCommand(minionsQuery, sqlConnection);

            getMinionsCmd
                .Parameters.AddWithValue("@VillainId", enteredId);

            using SqlDataReader minionsReader 
                = getMinionsCmd.ExecuteReader();

            if (!minionsReader.HasRows)
            {
                output.AppendLine($"(no minions)");
            }
            else
            {
                int rowNum = 1;

                while (minionsReader.Read())
                {
                    output.AppendLine($"{rowNum}. {minionsReader["Name"]} {minionsReader["Age"]}");
                    rowNum++;
                }
            }

            return output
                .ToString().TrimEnd();
        }

        //Problem 4
        private static string AddMinion(SqlConnection sqlConnection, string townName, string villainName, string minionName, int minionAge)
        {
            StringBuilder output = new StringBuilder();

            SqlTransaction sqlTransaction
                = sqlConnection.BeginTransaction();

            try
            {
                int townId = GetTownId(sqlConnection, sqlTransaction, townName, output);
                int villainId = GetVillainId(sqlConnection, sqlTransaction, villainName, output);
                int minionId = InsertMinionAndGetId(sqlConnection, sqlTransaction, minionName, minionAge, townId, villainName, output);

                string addMinionToVillainQuery = @"INSERT INTO [MinionsVillains]([MinionId], [VillainId])
                                                        VALUES
                                                               (@MinionId, @VillainId)";

                SqlCommand addMinionToVillainCmd
                    = new SqlCommand(addMinionToVillainQuery, sqlConnection, sqlTransaction);

                addMinionToVillainCmd
                    .Parameters.AddWithValue("@MinionId", minionId);
                addMinionToVillainCmd
                    .Parameters.AddWithValue("@VillainId", villainId);

                addMinionToVillainCmd.ExecuteNonQuery();

                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.Message;
            }

            return output.ToString().TrimEnd();
        }

        private static int GetTownId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string townName, StringBuilder output)
        {
            string getTownIdQuery = @"SELECT [Id]
                                        FROM [Towns]
                                       WHERE [Name] = @TownName";

            SqlCommand getTownIdCmd
                = new SqlCommand(getTownIdQuery, sqlConnection, sqlTransaction);

            getTownIdCmd
                .Parameters.AddWithValue("@TownName", townName);

            object townId = getTownIdCmd.ExecuteScalar();

            if (townId == null)
            {
                string insertMissingTownQuery = @"INSERT INTO [Towns]([Name])
                                                           VALUES
                                                                  (@TownName)";

                SqlCommand insertMissingTownCmd =
                    new SqlCommand(insertMissingTownQuery, sqlConnection, sqlTransaction);

                insertMissingTownCmd
                    .Parameters.AddWithValue("@TownName", townName);

                insertMissingTownCmd.ExecuteNonQuery();
                output.AppendLine($"Town {townName} was added to the database.");

                townId = getTownIdCmd.ExecuteScalar();
            }

            return (int)townId;
        }

        private static int GetVillainId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string villainName, StringBuilder output)
        {
            string getVillainIdQuery = @"SELECT [Id]
                                           FROM [Villains]
                                          WHERE [Name] = @VillainName";

            SqlCommand getVillainIdCmd
                = new SqlCommand(getVillainIdQuery, sqlConnection, sqlTransaction);

            getVillainIdCmd
                .Parameters.AddWithValue("@VillainName", villainName);

            object villainId = getVillainIdCmd.ExecuteScalar();

            if (villainId == null)
            {
                string insertMissingVillainQuery = @"INSERT INTO [Villains]([Name], [EvilnessFactorId])
                                                              VALUES
                                                                     (@VillainName, 4)";

                SqlCommand insertMissingVillainCmd
                    = new SqlCommand(insertMissingVillainQuery, sqlConnection, sqlTransaction);

                insertMissingVillainCmd
                    .Parameters.AddWithValue("@VillainName", villainName);

                insertMissingVillainCmd.ExecuteNonQuery();
                output.AppendLine($"Villain {villainName} was added to the database.");

                villainId = getVillainIdCmd.ExecuteScalar();
            }

            return (int)villainId;
        }

        private static int InsertMinionAndGetId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string minionName, int minionAge, int townId, string villainName, StringBuilder output)
        {
            string insertMinionQuery = @"INSERT INTO [Minions]([Name], [Age], [TownId])
                                                   VALUES
                                              (@MinionName, @MinionAge, @MinionTownId)";

            SqlCommand insertMinionCmd
                = new SqlCommand(insertMinionQuery, sqlConnection, sqlTransaction);

            insertMinionCmd
                .Parameters.AddWithValue("@MinionName", minionName);
            insertMinionCmd
                .Parameters.AddWithValue("@MinionAge", minionAge);
            insertMinionCmd
                .Parameters.AddWithValue("@MinionTownId", townId);

            insertMinionCmd.ExecuteNonQuery();
            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            string getMinionIdQuery = @"SELECT [Id]
                                              FROM [Minions]
                                             WHERE [Name] = @MinionName AND [Age] = @MinionAge AND TownId = @MinionTownId";

            SqlCommand getMinionQueryCmd
                = new SqlCommand(getMinionIdQuery, sqlConnection, sqlTransaction);

            getMinionQueryCmd
                .Parameters.AddWithValue("@MinionName", minionName);
            getMinionQueryCmd
                .Parameters.AddWithValue("@MinionAge", minionAge);
            getMinionQueryCmd
                .Parameters.AddWithValue("@MinionTownId", townId);

            int minionId = (int)getMinionQueryCmd.ExecuteScalar();

            return minionId;
        }

        //Problem 5
        private static string ChangeTownNameCasing(SqlConnection sqlConnection, string countryName)
        {
            StringBuilder output = new StringBuilder();

            string getCountryIdQuery = @"SELECT [Id]
                                           FROM [Countries]
                                          WHERE [Name] = @CountryName";

            SqlCommand getContryIdCmd 
                = new SqlCommand(getCountryIdQuery, sqlConnection);

            getContryIdCmd
                .Parameters.AddWithValue("@CountryName", countryName);

            object countryId = getContryIdCmd.ExecuteScalar();

            if (countryId == null)
            {
                return "No town names were affected.";
            }

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string updateTownCasingQuery = @"UPDATE [Towns]
                                                    SET [Name] = UPPER([Name])
                                                  WHERE [CountryCode] = @CountryId";

                SqlCommand updateTownCasingCmd 
                    = new SqlCommand(updateTownCasingQuery, sqlConnection, sqlTransaction);

                updateTownCasingCmd
                    .Parameters.AddWithValue("@CountryId", (int)countryId);

                int updatedTowns = updateTownCasingCmd.ExecuteNonQuery();
                output.AppendLine($"{updatedTowns} town names were affected.");

                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.Message;
            }

            string getTownNamesQuery = @"SELECT [Name]
                                           FROM [Towns]
                                          WHERE [CountryCode] = @CountryId";

            SqlCommand getTownNamesCmd 
                = new SqlCommand(getTownNamesQuery, sqlConnection);

            getTownNamesCmd
                .Parameters.AddWithValue("@CountryId", (int)countryId);

            using SqlDataReader reader = getTownNamesCmd.ExecuteReader();
            output.Append("[ ");

            int i = 1;

            while (reader.Read())
            {
                output.Append($"{reader["Name"]} ");
                i++;
            }

            reader.Close();

            output.AppendLine("]");

            return output.ToString().TrimEnd();
        }

        //Problem 6
        private static string RemoveVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder output = new StringBuilder();

            string getVillainNameQuery = @"SELECT [Name]
                                             FROM [Villains]
                                            WHERE [Id] = @VillainId";

            SqlCommand getVillainNameCmd
                = new SqlCommand(getVillainNameQuery, sqlConnection);

            getVillainNameCmd
                .Parameters.AddWithValue("@VillainId", villainId);

            string villainName = (string)getVillainNameCmd.ExecuteScalar();

            if (villainName == null)
            {
                return $"No such villain was found.";
            }

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string releaseMinionsQuery = @"DELETE FROM [MinionsVillains]
                                                     WHERE [VillainId] = @VillainId";

                SqlCommand releaseMinionsCmd
                    = new SqlCommand(releaseMinionsQuery, sqlConnection, sqlTransaction);

                releaseMinionsCmd
                    .Parameters.AddWithValue("@VillainId", villainId);

                int releasedMinions = releaseMinionsCmd.ExecuteNonQuery();

                string deleteVillainQuery = @"DELETE FROM [Villains]
                                                    WHERE [Id] = @VillainId";

                SqlCommand deleteVillainCmd
                    = new SqlCommand(deleteVillainQuery, sqlConnection, sqlTransaction);

                deleteVillainCmd
                    .Parameters.AddWithValue("@VillainId", villainId);

                deleteVillainCmd.ExecuteNonQuery();

                sqlTransaction.Commit();

                output
                    .AppendLine($"{villainName} was deleted.")
                    .AppendLine($"{releasedMinions} minions were released.");

            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.Message;
            }

            return output.ToString().TrimEnd();
        }

        //Problem 9
        private static string IncreaseMinionAge(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder output = new StringBuilder();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string executeProcedureQuery = @"EXEC [dbo].[usp_GetOlder] @MinionId";

                SqlCommand executeProcedureCmd
                    = new SqlCommand(executeProcedureQuery, sqlConnection, sqlTransaction);

                executeProcedureCmd
                    .Parameters.AddWithValue("@MinionId", minionId);

                executeProcedureCmd.ExecuteNonQuery();

                string getMinionInfoQuery = @"SELECT CONCAT([Name], ' - ', [Age], ' years old')
                                                  AS [Output]
                                                FROM [Minions]
                                               WHERE [Id] = @MinionId";

                SqlCommand getMinionInfoCmd
                    = new SqlCommand(getMinionInfoQuery, sqlConnection, sqlTransaction);

                getMinionInfoCmd
                    .Parameters.AddWithValue("@MinionId", minionId);

                using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();

                while (reader.Read())
                {
                    output.AppendLine($"{reader["Output"]}");
                }

                reader.Close();

                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.Message;
            }

            return output.ToString().TrimEnd();
        }
    }
}
