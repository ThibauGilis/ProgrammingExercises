document.querySelector('#play').addEventListener('click', () => {

    const randomIntFromInterval = (min, max) => { // min and max included 
        return Math.floor(Math.random() * (max - min + 1) + min)}

    let worpen = []
    for (let i=0; i<12; i++){
        nummer = randomIntFromInterval(1,6)
        worpen.push(nummer)
    }

    let zessen = 0;
    worpen.forEach(worp => {
        if(worp == 6){
            zessen++;
        }
    });
    antwoord = parseInt(prompt("Hoeveel spelers denk je dat er 6 gaan gooien?", 0))
    setTimeout(() => {
    // We tonen aan de gebruiker of hij juist geraden heeft.
    alert((antwoord == zessen) ? 'Gewonnen. Juist geraden!' : 'Oeps. ' + zessen + ' speler(s) gooiden een zes. Probeer nog eens...');
    }, 1000);

    for(let i=0; i<worpen.length;i++){
        if (worpen[i] == 6){
            let speler = document.querySelector(`#speler${i+1}`)
            speler.classList.add("bg-success");
            speler.classList.remove("bg-secondary");
        } 
    }

    // setTimeout(() => {
    // reset()
    // }, 1000)

})

let reset = () => {
    for(let i=0; i<12;i++){

        let speler = document.querySelector(`#speler${i+1}`)

        if (speler.classList.contains("bg-success")){

            speler.classList.remove("bg-success");
            speler.classList.add("bg-secondary");
        } 
    }
}

document.querySelector('#reset').addEventListener('click', () => reset() )