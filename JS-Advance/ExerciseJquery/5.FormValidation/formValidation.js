function validate() {
    let isChecked = false;

    $('#submit').on('click', validateForm);

    $('#company').change(function () {
        if (this.checked) {
            $('#companyInfo').css('display', 'block');
            isChecked = true;
        } else {
            $('#companyInfo').css('display', 'none');
            isChecked = false;
        }
    });

    function validateForm(event) {
        event.preventDefault();

        let isIncorect = false;
        let username = $('#username');
        let usernamePattern = /^[a-zA-Z0-9]{3,20}$/;
        if(!usernamePattern.test(username.val())){
            username.css('border-color', 'red');
            isIncorect = true;
        } else {
            username.css('border', 'none');
        }

        let password = $('#password');
        let confirmPassword = $('#confirm-password');
        let passPatt = /^\w{5,15}$/;
        if(!passPatt.test(password.val()) || password.val() == ""){
            password.css('border-color', 'red');
            isIncorect = true;
        }else {
            password.css('border', 'none');
        }

        if(!passPatt.test(confirmPassword.val()) || confirmPassword.val() == ""){
            confirmPassword.css('border-color', 'red');
            isIncorect = true;
        }else{
            confirmPassword.css('border', 'none');
        }

        if(password.val() != confirmPassword.val()|| password.val() == "" || confirmPassword.val() == ""){
            password.css('border-color', 'red');
            confirmPassword.css('border-color', 'red');
            isIncorect = true;
        } else {
            password.css('border', 'none');
            confirmPassword.css('border', 'none');
        }

        let mail = $('#email');
        let mailPatt = /^.*[@].*\..*$/;

        if(!mailPatt.test(mail.val())){
            mail.css('border-color', 'red');
            isIncorect = true;
        } else {
            mail.css('border', 'none');
        }

        let isCompany = $('#company');

        if (isChecked) {
            let companyNumber = $('#companyNumber');
            if(Number(companyNumber.val()) >= 1000 && Number(companyNumber.val()) <= 9999){
                companyNumber.css('border', 'none');
            } else {
                companyNumber.css('border-color', 'red');
                isIncorect = true;
            }
        }

        if(isIncorect){
            $('#valid').css('display', 'none');
        } else {
            $('#valid').css('display', 'block');
        }
    }
}
