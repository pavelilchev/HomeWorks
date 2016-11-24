function attachEvents() {
    const appID = 'kid_HyaHpWMzg';
    const masterSecret = '231ed1d4a6fb454686b1d5daf5008e73';
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_HyaHpWMzg/';
    const headers = {Authorization: 'Basic ' + btoa(appID + ':' + masterSecret), "Content-type": "application/json"};

    $('#btnAddCountry').click(addCountry);
    loadCountries();
    function loadCountries() {
        $.ajax({
            method: 'GET',
            url: baseUrl + 'Country',
            headers: headers
        }).then(displayCountries).catch(displayError)
    }

    function displayCountries(countries) {
        let cDiv = $('#countries');
        cDiv.empty();
        countries = countries.sort(function (a, b) {
            return a.name.localeCompare(b.name);
        });

        for (let country of countries) {
            let p = $(`<p data-id="${country._id}"><input type="text" value="${country.name}" id="txtCountry"/> <a href="#" id="btnEdit">[Edit]</a> <a  href="#" id="btnDelete">[Delete]</a></p>`);
            p.find('#btnEdit').click(editCountry);
            p.find('#btnDelete').click(deleteCountry);
            p.find('input').click(getTowns);
            cDiv.append(p);
        }
    }

    function editCountry() {
        let p = $(this).parent();
        let countryId = p.data('id');
        let name = p.find('input').val();
        $.ajax({
            method: 'PUT',
            url: baseUrl + 'Country/' + countryId,
            headers: headers,
            data : JSON.stringify({'name' : name})
        }).then(function (data) {
            let notice = $(`<span style="background: lawngreen">Changed!</span>`);
            p.append(notice);
            notice.fadeOut(2000, function () {
                $(this).remove();
            });
        }).catch(displayError);
    }

    function deleteCountry() {
        let that = $(this);
        let countryId = that.parent().data('id');
        $.ajax({
            method: 'DELETE',
            url: baseUrl + 'Country/' + countryId,
            headers: headers
        }).then(function (count) {
            that.parent().remove();
        }).catch(displayError)
    }

    function getTowns() {
        let that = $(this).parent();
        let countryName = that.find('input').val();
        let url = baseUrl + `Town?query={"country":"${countryName}"}`;
        $.ajax({
            method: 'GET',
            url: url,
            headers: headers
        }).then(displayTowns).catch(displayError);

        function displayTowns(towns) {
            let ul = $('<ul>');
            let addLi = $(`<li><input type="text" id="txtAddTown" value=""/> <a id="addTown" href="#">Add Town</a></li>`);
            ul.append(addLi);
            $(addLi).find('#addTown').click(addTown);

            for(let town of towns){
                let li = $(`<li><input type="text" id="txtTown" value="${town.name}"/> <a id="editTown" href="#">Edit</a> <a href="#" id="deleteTown" >Delete</a></li>`);
                ul.append(li);

                let townId = town._id;
                li.find('#editTown').click(function () {
                    let newTownName = li.find('input').val();
                    $.ajax({
                        method: 'PUT',
                        url: baseUrl + 'Town/' + townId,
                        headers: headers,
                        data : JSON.stringify({'name' : newTownName, 'country' : town.country})
                    }).catch(displayError)
                });
                li.find('#deleteTown').click(function () {
                    $.ajax({
                        method: 'DELETE',
                        url: baseUrl + 'Town/' + townId,
                        headers: headers
                    }).then(function () {
                        li.remove();
                    }).catch(displayError)
                });
            }

            that.find('ul').remove();
            that.append(ul);
        }

    }

    function displayError(error) {
        console.dir(error);
    }

    function addTown() {
        let townName = $('#txtAddTown').val();
        let countryName = $(this).closest('p').find('#txtCountry').val();
        let data = JSON.stringify({"name": townName, 'country':countryName});
        if (townName) {
            $.ajax({
                method: 'POST',
                url: baseUrl + 'Town',
                headers: headers,
                data: data
            }).then(loadCountries).catch(displayError)
        }
    }

    function addCountry() {
        let name = $('#txtCountry').val();
        let data = JSON.stringify({"name": name});
        if (name) {
            $.ajax({
                method: 'POST',
                url: baseUrl + 'Country',
                headers: headers,
                data: data
            }).then(loadCountries).catch(displayError)
        }
    }
}