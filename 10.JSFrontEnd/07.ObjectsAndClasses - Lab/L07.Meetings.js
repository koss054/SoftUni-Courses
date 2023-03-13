function manageMeetings(meetingsArray) {
  let meetingSchedule = {};

  for (const entry of meetingsArray) {
    const [weekday, name] = entry.split(" ");

    if (meetingSchedule.hasOwnProperty(weekday)) {
      console.log(`Conflict on ${weekday}!`);
    } else {
      meetingSchedule[weekday] = name;
      console.log(`Scheduled for ${weekday}`);
    }
  }

  for (const key in meetingSchedule) {
    console.log(`${key} -> ${meetingSchedule[key]}`);
  }
}

manageMeetings(["Monday Peter", "Wednesday Bill", "Monday Tim", "Friday Tim"]);
manageMeetings([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);
