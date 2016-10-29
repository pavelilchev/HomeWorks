function timer() {
    let start = $('#start-timer');
    let stop = $('#stop-timer');

    start.on('click', startTimer);
    stop.on('click', stopTimer);

    let hours = $('#hours');
    let minutes = $('#minutes');
    let seconds = $('#seconds');

    let timer;
    let isWorking = false;

    function step() {
        let currentSeconds = Number(seconds.text());
        let currentMin = Number(minutes.text());
        let currentHour = Number(hours.text());

        if (currentSeconds == 59) {
            currentSeconds = -1;
            currentMin++;
        }

        if (currentMin == 60) {
            currentMin = 0;
            currentHour++;
        }

        seconds.text((currentSeconds + 1) < 10 ? '' + '0' + (currentSeconds + 1) : (currentSeconds + 1));
        minutes.text(currentMin < 10 ? '' + '0' + currentMin :currentMin);
        hours.text(currentHour < 10 ? '' + '0' + currentHour : currentHour);
    }

    function startTimer() {
        if (!isWorking) {
            timer = setInterval(step, 1000);
        }

        isWorking = true;
    }

    function stopTimer() {
        isWorking = false;
        clearInterval(timer);
    }
}