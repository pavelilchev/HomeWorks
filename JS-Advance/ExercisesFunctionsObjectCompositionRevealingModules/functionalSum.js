function add(num) {
    let sum = 0;

    addNum.toString = function () {
       return sum;
    };

    function addNum(num) {
        sum += num;
        return addNum;
    }

    return addNum(num);
}


console.log(add(1)(6)(-3).toString());



