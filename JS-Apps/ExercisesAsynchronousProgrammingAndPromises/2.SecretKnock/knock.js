function func() {
    const appKey = 'kid_BJXTsSi-e';
    const appSecret = '447b8e7046f048039d95610c1b039390';
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock';

    const base64 = btoa(appKey + ':' + appSecret);
    const headers = { "Authorization": "Basic " + base64, "Content-type": "application/json" };

    $.ajax({
        method: 'POST',
        url: 'https://baas.kinvey.com/user/kid_BJXTsSi-e/login',
        headers: headers,
        data: JSON.stringify({"username": "guest", "password": "guest"})
    })
        .then(sendQueryRequest)
        .catch(displayError);

    let authToken;
    let loginHeaders;
    function sendQueryRequest(credential) {
         authToken = credential._kmd.authtoken;
         loginHeaders = { "Authorization" : 'Kinvey ' + authToken, "Content-type": "application/json"  };
        $.ajax({
            method: 'GET',
            url: baseUrl + '?query=Knock Knock.',
            headers: loginHeaders
        }).then(processRequest)
    }

    function processRequest (data) {
        console.log(data.answer);
        if(data.message){
            $.ajax({
                method: 'GET',
                url: baseUrl + `?query=${data.message}`,
                headers: loginHeaders
            }).then(processRequest)
        }
    }

    function displayError(error) {
        console.dir(error)
    }
}