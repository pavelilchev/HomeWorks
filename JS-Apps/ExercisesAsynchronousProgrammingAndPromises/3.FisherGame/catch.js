function attachEvents() {
    const appId = 'kid_H1Vk3jpWl';
    const user = 'user';
    const appSecret = 'd9f1351c44c5499e823ed6dfbe18ce8d';
    const base64 = btoa(appId + ':' + appSecret);
    const headers = { "Authorization": "Basic " + base64, "Content-type": "application/json" };
    const hostUrl = 'https://baas.kinvey.com/appdata/';
    const baseUrl = hostUrl + appId + '/biggestCatches';


    $('.load').click(loadAllCatches);
    $('.update').click(updateCatch);
    $('.add').click(addCatch);

    function addCatch() {
        let parent = $('#addForm');
        let anger = parent.find('.angler').val();
        let weight = Number(parent.find('.weight').val());
        let species = parent.find('.species').val();
        let location = parent.find('.location').val();
        let bait = parent.find('.bait').val();
        let captureTime = Number(parent.find('.captureTime').val());

        let data = JSON.stringify({"angler": anger, "weight": weight, "species": species, "location": location, "bait": bait, "captureTime": captureTime});

        $.ajax({
            method: 'POST',
            url: baseUrl,
            headers:headers,
            data:data
        }).catch(displayError)
    }

    function updateCatch() {
        let id = $(this).parent().data("id");
        let data = getData(id);
        $.ajax({
            method: 'PUT',
            url: baseUrl +'/' + id,
            headers:headers,
            data:data
        }).catch(displayError)
    }

    function deleteCatch() {
        let id = $(this).parent().data("id");
        $(this).parent().remove();
        $.ajax({
            method: 'DELETE',
            url: baseUrl +'/' + id,
            headers:headers
        }).catch(displayError)
    }

    function loadAllCatches() {
        $.ajax({
            url: baseUrl,
            headers:headers
        })
            .then(displayCatches)
            .catch(displayError)
    }


    function displayCatches(catches) {
        let wrapper = $('#catches');
        wrapper.empty();

        for(let cat of catches){

            let c =$(
          `<div class="catch" data-id="${cat._id}">
            <label>Angler</label>
            <input type="text" class="angler" value="${cat.angler}">
            <label>Weight</label>
            <input type="number" class="weight" value="${cat.weight}">
            <label>Species</label>
            <input type="text" class="species" value="${cat.species}">
            <label>Location</label>
            <input type="text" class="location" value="${cat.location}">
            <label>Bait</label>
            <input type="text" class="bait" value="${cat.bait}">
            <label>Capture Time</label>
            <input type="number" class="captureTime" value="${cat.captureTime}">
            <button class="update">Update</button>
            <button class="delete">Delete</button>
        </div>`);

            c.find('.update').click(updateCatch);
            c.find('.delete').click(deleteCatch);
            wrapper.append(c);
        }
    }

    function displayError(error) {
        $('#catches').text(error);
    }

    function getData(id) {
        let parent = $("[data-id='" + id + "']");
        let anger = parent.find('.angler').val();
        let weight = Number(parent.find('.weight').val());
        let species = parent.find('.species').val();
        let location = parent.find('.location').val();
        let bait = parent.find('.bait').val();
        let captureTime = Number(parent.find('.captureTime').val());

        return JSON.stringify({"angler": anger, "weight": weight, "species": species, "location": location, "bait": bait, "captureTime": captureTime});
    }
}