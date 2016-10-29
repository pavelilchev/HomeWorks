function attachEvents() {
    $('a.button').on('click', buttonClicked);
    function buttonClicked() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }

    function onListItemClick() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }

    $('ul').on('click', 'li', onListItemClick);

}
