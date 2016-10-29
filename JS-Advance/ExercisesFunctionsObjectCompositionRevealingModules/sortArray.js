function sortArray(arr, criteria) {
    let asc = function (a, b) {
        return a - b;
    };

    let desc = function (a, b) {
        return b- a;
    };

    let comparatorType = {
        asc : asc,
        desc : desc
    };

    return arr.sort(comparatorType[criteria]);
}

console.log(sortArray([14, 7, 17, 6, 8], 'desc'))