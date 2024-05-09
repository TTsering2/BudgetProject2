//This function generates formatted date output for the Budget Report API

export function getFirstAndLastDateOfMonth() {
  const today = new Date();
  const firstDayOfMonth = new Date(today.getFullYear(), today.getMonth(), 1);
  const lastDayOfMonth = new Date(today.getFullYear(), today.getMonth() + 1, 0);
  // Format the first and last dates as strings in "YYYY-MM-DDTHH:mm:ss.sssZ" format
  const firstDateString: string = formatDate(firstDayOfMonth);
  const lastDateString: string = formatDate(lastDayOfMonth);

  const dateUntilMonthEds = lastDayOfMonth - today;
  const differenceInDays = Math.floor(
    dateUntilMonthEds / (1000 * 60 * 60 * 24),
  );

  const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];
  const monthName = months[today.getMonth()];

  return {
    firstDate: firstDateString,
    lastDate: lastDateString,
    monthName: monthName + " " + today.getDate(),
    dateUntilMonthEds: differenceInDays,
  };
}

export function formatDate(date: Date): string {
  // Get the year, month, day, hours, minutes, seconds, and milliseconds of the date object
  const year: number = date.getFullYear();
  // TypeScript months are 0-based, so we add 1 to get the correct month
  const month: number = date.getMonth() + 1;
  const day: number = date.getDate();
  const hours: number = date.getHours();
  const minutes: number = date.getMinutes();
  const seconds: number = date.getSeconds();
  const milliseconds: number = date.getMilliseconds();

  // Pad single digits with leading zeros
  const formattedMonth: string = month < 10 ? `0${month}` : month.toString();
  const formattedDay: string = day < 10 ? `0${day}` : day.toString();
  const formattedHours: string = hours < 10 ? `0${hours}` : hours.toString();
  const formattedMinutes: string =
    minutes < 10 ? `0${minutes}` : minutes.toString();
  const formattedSeconds: string =
    seconds < 10 ? `0${seconds}` : seconds.toString();

  // Return the formatted date string in "YYYY-MM-DDTHH:mm:ss.sssZ" format
  return `${year}-${formattedMonth}-${formattedDay}T${formattedHours}:${formattedMinutes}:${formattedSeconds}.${milliseconds}Z`;
}
