
//This function generates formatted date output for the Budget Report API

export function getFirstAndLastDateOfMonth(year: number, month: number): { firstDate: string, lastDate: string } {
    // Create a new Date object with the given year and month (months are 0-based)
    const firstDate: Date = new Date(year, month, 1);
    const lastDate: Date = new Date(year, month + 1, 0);

    // Format the first and last dates as strings in "YYYY-MM-DDTHH:mm:ss.sssZ" format
    const firstDateString: string = formatDate(firstDate);
    const lastDateString: string = formatDate(lastDate);

    return { firstDate: firstDateString, lastDate: lastDateString };
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
    const formattedMinutes: string = minutes < 10 ? `0${minutes}` : minutes.toString();
    const formattedSeconds: string = seconds < 10 ? `0${seconds}` : seconds.toString();

    // Return the formatted date string in "YYYY-MM-DDTHH:mm:ss.sssZ" format
    return `${year}-${formattedMonth}-${formattedDay}T${formattedHours}:${formattedMinutes}:${formattedSeconds}.${milliseconds}Z`;
}

// Example usage:
const year: number = 2024;
const month: number = 4; // May (0-based)
const { firstDate, lastDate } = getFirstAndLastDateOfMonth(year, month);
console.log("First Date of the Month:", firstDate);
console.log("Last Date of the Month:", lastDate);
