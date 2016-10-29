function domSearch(selector, isCaseSensitive) {
    let addDiv = $('<div>').addClass('add-controls');
    let addLabel = $('<label>Enter text:</label>');
    let addInput = $('<input>');
    let addBtn = $('<a>Add</a>').addClass('button');
    addBtn.on('click', addItem);

    addLabel.append(addInput);
    addDiv.append(addLabel);
    addDiv.append(addBtn);


    let searchDiv = $('<div>').addClass('search-controls');
    let searchLabel = $('<label>Search:</label>');
    let searchInput = $('<input>');
    searchInput.on('input', search);

    searchLabel.append(searchInput);
    searchDiv.append(searchLabel);

    let resultDiv = $('<div>').addClass('result-controls');
    let resultUl = $('<ul>').addClass('items-list');

    resultDiv.append(resultUl);


    $(selector).append(addDiv);
    $(selector).append(searchDiv);
    $(selector).append(resultDiv);

    function addItem() {
        let name = addInput.val();
        addInput.val(' ');
        let li = $('<li>').addClass('list-item');
        let a = $('<a>X</a>').addClass('button');
        a.on('click', deleteItem);
        li.append(a);
        li.append('<strong>' + name + '</strong>')

        resultUl.append(li);
    }

    function deleteItem() {
        $(this).parent().remove();
    }

    function search() {
        let needle = $(this).val();
        let items = $('.list-item strong').toArray();
        for (let item of items) {
            let current = $(item);

            if (isCaseSensitive) {
                if (current.text().indexOf(needle) < 0) {
                    current.parent().css('display', 'none')
                } else {
                    current.parent().css('display', '')
                }
            } else {
                if (current.text().toLowerCase().indexOf(needle.toLowerCase()) < 0) {
                    current.parent().css('display', 'none')
                } else {
                    current.parent().css('display', '')
                }
            }

        }
    }
}