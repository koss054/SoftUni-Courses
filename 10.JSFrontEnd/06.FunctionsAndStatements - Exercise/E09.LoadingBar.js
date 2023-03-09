function printLoadingBar(percentage) {
  let loadingBar = "[..........]".split("");
  const loadProgress = percentage / 10;

  for (let i = 1; i <= loadProgress; i++) {
    loadingBar[i] = "%";
  }

  let output = `${percentage}%`;

  if (percentage === 100) {
    output += " Complete!";
  } else {
    output += ` ${loadingBar.join("")}`;
    output += "\nStill loading...";
  }

  console.log(output);
}

printLoadingBar(30);
printLoadingBar(50);
printLoadingBar(100);
