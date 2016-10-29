let a = (function cards() {
    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣'
    };

    let validFaces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(value) {
            if(validFaces.indexOf(value) < 0){
                throw new Error('Invalid face detected!');
            }

            this._face = value;
        }

        get suit() {
            return this._suit;
        }

        set suit(value) {
            let that = this;
            let isSet = false;
            Object.keys(Suits).forEach(function (s) {
                if(Suits[s] == value) {
                    that._suit = value;
                    isSet = true;
                }
            });

            if(!isSet)
            throw new Error('Invalid suit!');
        }
    }


    return {
        Suits:Suits,
        Card:Card
    }
})();

let card = new a.Card('Q','♣')
console.log(card)