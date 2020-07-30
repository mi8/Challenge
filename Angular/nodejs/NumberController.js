const express = require('express');
const app = express()
app.use(express.json())
const cors = require('cors')

app.use(cors())
app.use(function (req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Methods", "GET, POST, HEAD, OPTIONS, PUT, PATCH, DELETE");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, x-access-token, x-refresh-token, _id");

    res.header(
        'Access-Control-Expose-Headers',
        'x-access-token, x-refresh-token'
    );

    next();
});


const getRandomNumber = (min, max) => {
    return Math.random() * (max - min) + min;
}

function verify(randomNumber, guess) {
    if (randomNumber === guess) {
        return 0
    } else if (randomNumber < guess) {
        return -1
    } else if (randomNumber > guess) {
        return 1
    }
}


app.get('/api/number/:num', (req, res) => {
    let tries = 20
    let tried = 0
    let toGuess = parseInt(req.params.num)
    if (req.params.id == 0) {
        toGuess = parseInt(getRandomNumber(1, 50000))
    }
    let highest = 50000
    let lowest = 1
    let randomNumber = 0
    let answer
    function game() {
        for (let i = 0; i <= 20; i++) {
            if (tries > 0) {
                randomNumber = parseInt(getRandomNumber(lowest, highest))
                if (verify(randomNumber, toGuess) === -1) {
                    tries -= 1
                    tried += 1
                    lowest = randomNumber
                } if (verify(randomNumber, toGuess) === 1) {
                    tries -= 1
                    tried += 1
                    highest = randomNumber
                } if (verify(randomNumber, toGuess) === 0) {
                    tried += 1
                    console.log(`You won after ${tried} times`)
                    res.json({ message: `You Won, The Computer found the number after ${tried} tries, You got lucky ! The Number was ${toGuess}`,answer:true })
                    break
                }
            } else {
                res.json({ message: `Sorry, The Computer couldn't find the answer after ${tried} tries, tough Luck , the Number was ${toGuess} and the computer's last number was ${randomNumber}`, answer:false })
                console.log(`You Lost`)
                break
            }
        }
    }
    game()
})


app.listen(3000, () => {
    console.log("Server is listening on port 3000")
})

