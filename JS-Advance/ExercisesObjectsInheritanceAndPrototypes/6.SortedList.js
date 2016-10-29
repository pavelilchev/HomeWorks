function sortedList() {
    let obj = {};
    let list = [];

    obj.size = 0;
    obj.add = function (element) {
        list.push(element);
        sort();
        obj.size++;
    };

    obj.remove = function (index) {
        if (index < 0 || index > list.length - 1) {
            throw new Error('Index out of range');
        }

        list.splice(index, 1);
        sort();
        obj.size--;
    };

    obj.get = function (index) {
        if (index < 0 || index > list.length - 1) {
            throw new Error('Index out of range');
        }

        return list[index];
    };

    function sort() {
        list.sort((a, b) => a - b);
    }

    return obj;
}

let list = sortedList();

list.add(1)
list.add(3)
list.add(2)

console.log(list.size);
console.log(list.remove(4));