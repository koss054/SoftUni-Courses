using Exam.Categorization;

var categorizator = new Categorizator();
var A = new Category("A", "A", "A");
var B = new Category("B", "B", "B");
var C = new Category("C", "C", "C");
var D = new Category("D", "D", "D");
var E = new Category("E", "E", "E");
var F = new Category("F", "F", "F");
var G = new Category("G", "G", "G");

categorizator.AddCategory(A);
categorizator.AddCategory(B);
categorizator.AddCategory(C);
categorizator.AddCategory(D);
categorizator.AddCategory(E);
categorizator.AddCategory(F);
categorizator.AddCategory(G);

categorizator.AssignParent("B", "A");
categorizator.AssignParent("C", "B");
categorizator.AssignParent("D", "C");
categorizator.AssignParent("E", "D");
categorizator.AssignParent("F", "E");
categorizator.AssignParent("G", "F");

var firstHierarchy = categorizator.GetHierarchy("D");
var secondHierarchy = categorizator.GetHierarchy("G");

Console.WriteLine(String.Join(", ", firstHierarchy.Select(x => x.Name)));
Console.WriteLine(String.Join(", ", secondHierarchy.Select(x => x.Name)));