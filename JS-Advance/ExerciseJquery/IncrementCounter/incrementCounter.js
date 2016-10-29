function increment(selector) {
    let element = $(selector);
    let area = $('<textarea>')
        .addClass("counter")
        .val(0)
        .attr('disabled', true);

    let incrBtn = $('<button>')
        .addClass('btn')
        .attr('id', 'incrementBtn')
        .text('Increment');

    incrBtn.on('click', increment);

    let addBtn = $('<button>')
        .addClass('btn')
        .attr('id', 'addBtn')
        .text('Add');

    addBtn.on('click', addLi);

    let ul = $('<ul>').addClass('results');
    element.append(area);
    element.append(incrBtn);
    element.append(addBtn);
    element.append(ul);

    function increment() {
        area.val(Number(area.val()) + 1);
    }

    function addLi() {
        let val = area.val();
        let li = $('<li>').text(val);
        ul.append(li);
    }
}
