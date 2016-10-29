function solve(arr) {
    function reducer(arr, func){
        let result = arr[0];
        arr = arr.slice(1);
        for(let el of arr){
            result =  func(result, el);
        }

        return result;
    }

    console.log('Sum = ' + reducer(arr, (a,b) => a + b));
    console.log('Min = ' + reducer(arr, (a,b) => {if(a < b)return a; else return b;}));
    console.log('Max = ' + reducer(arr, (a,b) => {if(a > b)return a; else return b;}));
    console.log('Product = ' + reducer(arr, (a,b) => a * b));
    console.log('Join = ' + reducer(arr, (a,b) => a.toString() + b.toString()));
}


solve([2,3,10,5])