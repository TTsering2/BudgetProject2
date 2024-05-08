/**
 * Formats the date string to the C# format.
 * @param dateStr The date string in "YYYY-MM-DD" format from an HTML input element.
 * @returns A string in C# DateTime format: "yyyy-MM-ddTHH:mm:ssZ".
 */
export const FormatDateToCsharp = (dateStr: string): string => {
    const date = new Date(dateStr);
    date.setUTCHours(0, 0, 0, 0);
    return date.toISOString();
}

/**
 * Computes the first and last day of the month for the given date string.
 * @param dateStr The date string in "YYYY-MM-DD" format from an HTML input element.
 * @returns An object containing the first and last day of the month, both set to midnight UTC.
 */
export function getMonthBounds(dateStr: string): { firstDay: string, lastDay: string } {
    const date = new Date(dateStr);

    // First day of the month
    const firstDay = new Date(Date.UTC(date.getFullYear(), date.getMonth(), 1));
    firstDay.setUTCHours(0, 0, 0, 0);  
    const firstDayString = firstDay.toISOString();  

    // Last day of the month
    const lastDay = new Date(Date.UTC(date.getFullYear(), date.getMonth() + 1, 0));
    lastDay.setUTCHours(23, 59, 59, 999);  
    const lastDayString = lastDay.toISOString();  

    return { firstDay: firstDayString, lastDay: lastDayString };
}

/**
 * Extracts the year and month from a date string in ISO format.
 * @param isoDateString The date string in "YYYY-MM-DDT00:00:00.000Z" format.
 * @returns An object containing the year and month.
 */
export function extractYearAndMonth(isoDateString: string): { year: number, month: number, monthName: string } {
    const date = new Date(isoDateString);

    const year = date.getUTCFullYear();  
    const month = date.getUTCMonth() + 1;  

    const monthName = date.toISOString();

    return { year, month, monthName };
}

/**
 * Computes the first and last day of the year for the given date string.
 * @param dateStr The date string in "YYYY-MM-DD" format from an HTML input element.
 * @returns An object containing the first and last day of the year, both set to midnight UTC.
 */
export function getYearBounds(dateStr: string): { firstDay: string, lastDay: string } {
    const date = new Date(dateStr);

    // First day of the year
    const firstDay = new Date(Date.UTC(date.getFullYear(), 0, 1)); 
    firstDay.setUTCHours(0, 0, 0, 0); 
    const firstDayString = firstDay.toISOString(); 

    // Last day of the year
    const lastDay = new Date(Date.UTC(date.getFullYear(), 11, 31));
    lastDay.setUTCHours(23, 59, 59, 999); 
    const lastDayString = lastDay.toISOString(); 

    return { firstDay: firstDayString, lastDay: lastDayString };
}
