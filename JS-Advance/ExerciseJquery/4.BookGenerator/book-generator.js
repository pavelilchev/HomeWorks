(function createBook() {
    let counter = 1;

    return function (selector, title, author, ISBN) {
        let fragment = document.createDocumentFragment();
        let container = $(selector);

        let book = $('<div>').attr('id', 'book' + counter);
       counter++;
        let titleP = $('<p>').addClass('title').text(title);
        let authorP = $('<p>').addClass('author').text(author);
        let isbnP = $('<p>').addClass('isbn').text(ISBN);
        let select = $('<button>Select</button>');
        let deselect = $('<button>Deselect</button>');

        select.on('click',   function () {
            book.css('border', '2px solid blue');
        });

        deselect.on('click', function () {
            book.css('border', 'none');
        });

        book
            .append(titleP)
            .append(authorP)
            .append(isbnP)
            .append(select)
            .append(deselect);

        book.appendTo(fragment);
        container.append(fragment);
    }
}());