function subtract() {
    let firstNumber = parseFloat($('#firstNumber').val());
    let secondNumber = parseFloat($('#secondNumber').val());

    let result = firstNumber - secondNumber;
    $('#result').text(result);
}
