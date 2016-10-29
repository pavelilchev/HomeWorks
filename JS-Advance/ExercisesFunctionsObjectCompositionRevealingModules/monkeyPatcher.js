function result(command) {
    let that = this;
    let patcher = (function () {
        function upvote() {
            that.upvotes++;
        }

        function downvote() {
            that.downvotes++;
        }

        function score() {
            let addedVotes = 0;
            if (that.upvotes + that.downvotes > 50) {
                addedVotes = Math.ceil(Math.max(that.upvotes, that.downvotes) * 0.25);
            }
            let up = that.upvotes + addedVotes;
            let down = that.downvotes + addedVotes;
            let score = that.upvotes - that.downvotes;
            let rating = '';

            if (that.upvotes + that.downvotes < 10) {
                rating = 'new';
            } else if (that.upvotes / (that.upvotes + that.downvotes) > 0.66) {
                rating = 'hot';
            } else if (that.upvotes - that.downvotes >= 0 &&
                that.upvotes + that.downvotes > 100) {
                rating = 'controversial';
            } else if (that.upvotes - that.downvotes < 0) {
                rating = 'unpopular';
            } else {
                rating = 'new';
            }

            return [up, down, score, rating];
        }

        return {
            upvote, downvote, score
        }
    })();

    return patcher[command]();
}

var forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 0
};

result.call(forumPost, 'upvote');
var answer = result.call(forumPost, 'score');
console.log(answer)