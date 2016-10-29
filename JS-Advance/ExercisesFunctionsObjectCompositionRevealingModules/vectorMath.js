solution ={
    add : function(vec1, vec2) {
        return [vec1[0] + vec2[0], vec1[1] + vec2[1]];
    },
    multiply : function (vec1, scalar) {
        return [vec1[0]*scalar, vec1[1]*scalar];
    },
    length : function (vec) {
        return  Math.sqrt(vec[0]*vec[0]+ vec[1]*vec[1]);
    },
    dot: function (vec1, vec2) {
        return vec1[0]*vec2[0] + vec1[1]* vec2[1];
    },
    cross:function (vec1, vec2) {
        return vec1[0]*vec2[1] - vec1[1] * vec2[0];
    }
};

console.log(solution.cross([3, 7], [1, 0]));