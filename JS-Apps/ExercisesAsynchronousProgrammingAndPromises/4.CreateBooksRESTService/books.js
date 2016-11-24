function attachEvents() {
    const appKey = 'kid_SJr9CWCbe';
    const baseUrl = 'https://baas.kinvey.com/appdata/' + appKey + '/Book';
    const user = 'user';
    const pass = 'user';
    const headers = {'Authorization': `Basic ${btoa(user + ':' + pass)}`, 'Content-type': 'application/json'};

    $('#btnCreate').click(createBook);

    listAllBooks();

    function createBook() {
        let author = $('#txtAuthor').val();
        let title = $('#txtTitle').val();
        let isbn = $('#txtISBN').val();

        if(author && title && isbn){
            $('#txtAuthor').val('');
            $('#txtTitle').val('');
            $('#txtISBN').val('');

            $.ajax({
                method:'POST',
                url:baseUrl,
                headers:headers,
                data:JSON.stringify({title:title,author:author, isbn:isbn})
            }).then(listAllBooks).catch(displayError);
            $('#btnCreate').css('background', 'green');
        } else {
            $('#btnCreate').css('background', 'red');
        }
    }

    function listAllBooks() {
        $.ajax({
            url: baseUrl,
            headers: headers
        })
            .then(displayBooks)
            .catch(displayError);
    }

    function displayBooks(books) {
        $('#books').empty();

        for (let book of books) {
            let bookDiv = $(`
<div id="book" style="border-bottom: 1px solid #CCC; max-width: 640px; padding: 10px 0">
<span>Заглавие: </span>
<span id="spnTitle">${book.title}</span><br>
<span>Автор: </span>
<span id="spnAuthor">${book.author}</span><br>
<span>ИСБН:</span>
<span id="spnISBN">${book.isbn}</span><br>
</div>`);

            $('#books').append(bookDiv);
            bookDiv.click(editBook);
        }
    }

    function editBook() {
        $('#txtAuthor').val($(this).find('#spnAuthor').text());
        $('#txtTitle').val($(this).find('#spnTitle').text());
        $('#txtISBN').val($(this).find('#spnISBN').text());


    }

    function displayError(error) {
        $('#books').text(JSON.stringify(error));
    }
}