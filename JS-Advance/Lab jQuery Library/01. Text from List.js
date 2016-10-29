function extractText() {
    let result = [];

    let lis = $('#items li').each(function(){
       result.push($(this).text());
    });
    $('#result').text(result.join(', '));
}
