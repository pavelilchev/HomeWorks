function personalBMI(name, age, weight, height) {
    let patient = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: Math.round(weight / (height / 100 * height / 100))
    };

    patient['status'] =  (function () {
        if(patient.BMI < 18.5){
            return 'underweight';
        } else if(patient.BMI < 25){
            return 'normal';
        } else  if(patient.BMI < 30){
            return 'overweight';
        } else {
            return 'obese';
        }
    })();

    if(patient['status'] == 'obese'){
        patient['recommendation'] = 'admission required';
    }

    return patient;
}

personalBMI('Honey Boo Boo', 9, 57, 137);