function printSongInfo(infoArray) {
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  let songs = [];
  let numOfSongs = Number(infoArray[0]);
  let searchedType = "";

  for (let i = 0; i < infoArray.length; i++) {
    if (i > 0 && i < infoArray.length - 1) {
      const songInfo = infoArray[i].toString().split("_");
      songs.push(new Song(songInfo[0], songInfo[1], songInfo[2]));
      numOfSongs--;
    }

    if (numOfSongs === 0) {
      searchedType = infoArray[infoArray.length - 1].toString();
    }
  }

  if (searchedType == "all") {
    for (const song of songs) {
      console.log(song.name);
    }
  } else {
    for (const song of songs) {
      if (song.typeList == searchedType) {
        console.log(song.name);
      }
    }
  }
}

printSongInfo([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);

printSongInfo([
  4,
  "favourite_DownTown_3:14",
  "listenLater_Andalouse_3:24",
  "favourite_In To The Night_3:58",
  "favourite_Live It Up_3:48",
  "listenLater",
]);

printSongInfo([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
