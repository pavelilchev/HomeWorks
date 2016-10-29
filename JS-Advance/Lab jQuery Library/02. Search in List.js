function search() {
    let searchText = $('#searchText').val();
    let count = 0;
    let towns = $('li').each(function(index){
        if($(this).text().indexOf(searchText) >= 0){
            count++;
            $(this).css('font-weight', 'bold');
        } else {
            $(this).css('font-weight', '');
        }
    });

    $('#result').text(count + ' matches found.')
}
