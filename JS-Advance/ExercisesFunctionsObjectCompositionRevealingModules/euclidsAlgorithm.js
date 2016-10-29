function euclidsAlgorithm(firstNum, secondNum) {
    if (secondNum == 0) {
        return firstNum;
    }

    return euclidsAlgorithm(secondNum, firstNum % secondNum);
}

console.log(euclidsAlgorithm(252, 105));
