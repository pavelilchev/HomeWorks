function attachEvents() {
    const appId = 'kid_H1F2Jtmfe';
    const appSecret = '482128408df542e699537ebd092a5a2e';
    const baseUrl = 'https://baas.kinvey.com/appdata/';
    const base64 = btoa(appId + ':' + appSecret);

    loadPlayers();

    $('#addPlayer').click(function () {
        let name = $('#addName').val();
        if (name) {
            $('#addName').val('');
            $.ajax({
                method: 'POST',
                url: baseUrl + appId + '/players',
                headers: {
                    'Authorization': 'Basic ' + base64,
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify({'name': name, 'money': 500, 'bullets': 6})
            }).then(loadPlayers).catch(displayError)
        }
    });

    function loadPlayers() {
        $('#players').empty();
        $.ajax({
            method: 'GET',
            url: baseUrl + appId + '/players',
            headers: {
                'Authorization': 'Basic ' + base64,
                'Content-Type': 'application/json'
            }
        }).then(displayPlayers).catch(displayError)
    }

    function displayPlayers(players) {
        let playersWrapper = $('#players');

        for (let player of players) {
            let playerDiv =
                $(`<div class="player" data-id="${player._id}">
            <div class="row">
                <label>Name:</label>
                <label class="name">${player.name}</label>
            </div>
            <div class="row">
                <label>Money:</label>
                <label class="money">${player.money}</label>
            </div>
            <div class="row">
                <label>Bullets:</label>
                <label class="bullets">${player.bullets}</label>
            </div>
            <button class="play">Play</button>
            <button class="delete">Delete</button>
        </div>`);

            attachPlayerEvents(playerDiv);
            playersWrapper.append(playerDiv);
        }
    }

    function attachPlayerEvents(playerDiv) {
        let id = playerDiv.data('id');
        playerDiv.find('.delete').click(function () {
            $.ajax({
                method: 'DELETE',
                url: baseUrl + appId + '/players/' + id,
                headers: {
                    'Authorization': 'Basic ' + base64,
                    'Content-Type': 'application/json'
                }
            }).then(loadPlayers).catch(displayError)
        });

        playerDiv.find('.play').click(function () {
            let name = playerDiv.find('.name').text();
            let money = Number(playerDiv.find('.money').text());
            let bullets = Number(playerDiv.find('.bullets').text());
            $('#save').show();
            $('#reload').show();
            $('canvas').show();
            let player = {name: name, money: money, bullets: bullets}
            loadCanvas(player);
            $('#save').click(function () {
                saveGame(id, player);
            });

            $('#reload').click(function () {
                reload(id, player);
            });
        });
    }

    function saveGame(playerId, player) {
        $('#save').hide();
        $('#reload').hide();
        $('canvas').hide();
        clearInterval(canvas.intervalId);

        $.ajax({
            method: 'PUT',
            url: baseUrl + appId + '/players/' + playerId,
            headers: {
                'Authorization': 'Basic ' + base64,
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({'name': player.name, 'money': player.money, 'bullets': player.bullets})
        }).then(loadPlayers).catch(displayError)
    }

    function reload(playerId, player) {
        player.money -= 60;
        player.bullets = 6;

        $.ajax({
            method: 'PUT',
            url: baseUrl + appId + '/players/' + playerId,
            headers: {
                'Authorization': 'Basic ' + base64,
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({'name': player.name, 'money': player.money, 'bullets': player.bullets})
        }).catch(displayError)
    }

    function displayError(error) {
        console.dir(error);
    }
}