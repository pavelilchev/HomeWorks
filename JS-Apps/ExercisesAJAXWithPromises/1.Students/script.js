(function attachEvents() {
    $('#btnListStudents').click(getStudentsLogin);
    $('#btnCreateStudent').click(createStudent);

    const baseUrl = 'https://baas.kinvey.com/appdata/';
    const appKey = 'kid_BJXTsSi-e';
    const appSecret = '447b8e7046f048039d95610c1b039390';
    const username = 'guest';
    const pass = 'guest';
    let authToken;

    (function getCredential() {
        $.ajax({
            method: 'POST',
            url: `https://baas.kinvey.com/user/${appKey}/login`,
            headers: {"Authorization": "Basic " + btoa(appKey + ':' + appSecret), "Content-type": "application/json"},
            data: JSON.stringify({"username": username, "password": pass})
        }).then(function (credential) {
            authToken = credential._kmd.authtoken;
        }).catch(displayError)
    })();

    function getStudentsLogin() {
        loginHeaders = {"Authorization": 'Kinvey ' + authToken, "Content-type": "application/json"};
        $.ajax({
            method: 'GET',
            url: baseUrl + appKey + '/students/',
            headers: loginHeaders
        }).then(displayStudents)
    }

    function displayStudents(students) {
        students = students.sort(function (a, b) {
            return a.ID - b.ID;
        });
        let table = $('#results');
        for (let student of students) {
            let row =
                `<tr>
                    <td>${student.ID}</td>
                    <td>${student.FirstName}</td>
                    <td>${student.LastName}</td>
                    <td>${student.FacultyNumber}</td>
                    <td>${student.Grade}</td>
                </tr>`;

            table.append(row);
        }
    }

    function createStudent() {
        let id = $('#studentID').val();
        let fName = $('#studentFirstName').val();
        let lName = $('#studentLastName').val();
        let faculty = $('#studentFacultyNumber').val();
        let grade = $('#studentGrade').val();
        if(id && fName && lName && Number(faculty) && grade){
            loginHeaders = {"Authorization": 'Kinvey ' + authToken, "Content-type":"application/json"};
            $.ajax({
                method: 'POST',
                url: baseUrl + appKey + '/students/',
                headers: loginHeaders,
                data:JSON.stringify({'ID':Number(id),'FirstName':fName,'LastName':lName,'FacultyNumber':faculty,'Grade':Number(grade)})
            }).then(success).catch(displayError);
        }
    }

    function success(data) {
        console.dir(data)
    }

    function displayError(error) {
        console.dir(error)
    }
})();