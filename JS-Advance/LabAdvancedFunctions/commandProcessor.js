function commandProcessor(input) {
    let processor = (function () {
        let str = '';
        return {
            append : (s) => str += s,
            removeStart : (num) => str = str.slice(num),
            removeEnd : (num) => str = str.slice(0, str.length - num),
            print : () => console.log(str)
        }
    })();

    for (let row of input) {
        let [command, arg] = row.split(' ');
        processor[command](arg);
    }

}

commandProcessor(['append 123',
    'append 45',
    'removeStart 2',
    'removeEnd 1',
    'print']);