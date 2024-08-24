const randomNumberBetween = (min, max) => {
    return Math.floor(Math.random()*(max-min)+min);
}

const changeFoodPos = () => {
    do {
        foodY = randomNumberBetween(1,31), foodX = randomNumberBetween(1,31);
    } while (snakeBody.findIndex(pos => pos == [foodY, foodX]) !== -1);
}

const initGame = () => {
    if (snakeBody.length === score+1){
        snakeBody = snakeBody.slice(1,snakeBody.length);
    }
    snakeY += velocityY;
    snakeX += velocityX;
    snakeBody.push([snakeY, snakeX])

    if (snakeY <= 0 || snakeY > 30 || snakeX <= 0 || snakeX > 30) {
        clearInterval(gameInterval);
        alert("snek ded");
        location.reload();
        return;
    }
    if (snakeY === foodY && snakeX === foodX) {
        score++;
        if (score > highscore) {
            highscore++;
            localStorage.setItem("high-score", highscore);
        }

        gameDetails.innerHTML = `<span class="score">Score: ${score}</span> 
                                <span class="high-score">High Score: ${highscore}</span>`;
        changeFoodPos();
    }

    let htmlMarkup = `<div class="food" style="grid-area: ${foodY} / ${foodX}"></div>`;
    console.log(snakeBody);
    snakeBody.forEach(pos => {
        htmlMarkup += `<div class="snake" style="grid-area: ${pos[0]} / ${pos[1]}"></div>`;
    });

    playBoard.innerHTML = htmlMarkup;
}

//------------------------------------------------------------------------------------------------------

const playBoard = document.querySelector(".play-board");
const gameDetails = document.querySelector(".game-details");

let score = 0, highscore = localStorage.getItem("high-score") || 0;
gameDetails.innerHTML = `<span class="score">Score: ${score}</span> 
                        <span class="high-score">High Score: ${highscore}</span>`;

let foodY, foodX;
let snakeY = 3, snakeX = 3;
let snakeBody = [[snakeY, snakeX]];
let velocityY = 0, velocityX = 1;

changeFoodPos();
let gameInterval = setInterval(initGame, 125);

document.addEventListener("keydown", (e) => {
    switch(e.key){
        case "z":
            velocityY = -1;
            velocityX = 0;
            break;
        case "d":
            velocityY = 0;
            velocityX = 1;
            break;
        case "s":
            velocityY = 1;
            velocityX = 0;
            break;
        case "q":
            velocityY = 0;
            velocityX = -1;
            break;
        default:
            break;
    };
})