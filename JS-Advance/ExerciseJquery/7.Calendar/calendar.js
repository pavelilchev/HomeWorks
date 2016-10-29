function calendar([day,month,year]) {
    month = month - 1;
    let monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    let caption = monthNames[month] + ' ' + year;
    let container = $('#content');
    let table = $('<table>');
    table.append($('<caption>').text(caption));
    table.append($('<tbody>'));
    let headRow = $('<tr>');
    headRow.append($('<th>Mon</th>'));
    headRow.append($('<th>Tue</th>'));
    headRow.append($('<th>Wed</th>'));
    headRow.append($('<th>Thu</th>'));
    headRow.append($('<th>Fri</th>'));
    headRow.append($('<th>Sat</th>'));
    headRow.append($('<th>Sun</th>'));

    table.append(headRow);

    let lastDatePreviousMonth = new Date(year, month, 0);
    let currentMonthDays = new Date(year, month + 1, 0).getDate();
    let startDayOfWeek = lastDatePreviousMonth.getDay() + 1;
    let weeks = Math.ceil((currentMonthDays + startDayOfWeek - 1)/7);
    let currentDay = 1;

    currentDay = currentDay - startDayOfWeek + 1;

    for (let i = 0; i < weeks; i++) {
        let row = $('<tr>');
        for (let j = 0; j < 7; j++) {

            let td = $('<td>');
            if (currentDay > 0 && currentDay <= currentMonthDays) {
                td.text(currentDay);
                if(currentDay == day){
                    td.addClass('today');
                }
            } else {
                td.text('');
            }

            row.append(td);
            currentDay++;
        }

        table.append(row);
    }

    container.append(table);
}