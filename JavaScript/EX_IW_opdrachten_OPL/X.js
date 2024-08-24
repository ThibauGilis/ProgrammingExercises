// Declaratie elementen
const tbodyEl = document.querySelector("#tbody");
const zoekEl = document.querySelector("#search");
const nGevonden = document.querySelector("#nGevonden");
const frm = document.studForm;

// De JSON-file
const file = 'studenten_tm_output.json';

// De globale array
let workingData = [];

// ********* ZOEKEN *************
const zoekStud = () => {
    let search = zoekEl.value;

    if (search.length > 0) {
        // console.log("bfilter: ", workingData);
        workingData = workingData.filter(item => item.geg.achternaam.toLowerCase().indexOf(search
            .toLowerCase()) > -1);
        // console.log("afilter: ", workingData);
    }

    showData();
};

// ********* DATA OPVRAGEN *************
const getData = () => {

    // fetch de data
    fetch(file)
        .then(response => {
            if (response.status !== 200) {
                console.log('Blijkbaar toch een probleem... Status code: ' +
                    response.status);
                // Hier werken met Trow, niet gezien in de lessen...
                return;
            }
            return response.json();
        })
        .then((data) => {
            // We clonen de array naar de globale array
            workingData = data.slice();
            // workingData = [...data];
            zoekStud();
        })
        .catch(err => {
            console.log('Error: ', err.statusText + '(' + err.status + ')');
        }); // End fetch
};

// ********* TOON RESULT *************
const showData = () => {
    // Leeg maken
    tbodyEl.innerHTML = "";
    nGevonden.style.display = 'block';

    // Check of filter (checkbox) aangevinkt is
    workingData = filterStuds();

    // Studenten gevonden?
    if (workingData.length > 0) {
        nGevonden.innerHTML = `We hebben <strong>${workingData.length}</strong> student(en) gevonden`;
        nGevonden.classList.remove("alert-danger");
        nGevonden.classList.add("alert-success");
    } else {
        nGevonden.innerHTML = `We hebben <strong>${workingData.length}</strong> student(en) gevonden`;
        nGevonden.classList.add("alert-danger");
        nGevonden.classList.remove("alert-success");
    }

    // De tabel opvullen met data
    let tableData = '';
    workingData.forEach(stud => {
        tableData +=
            `<tr>
            <th scope="row">${stud.id}</th>
            <td>${stud.geg.achternaam}</td>
            <td>${stud.geg.voornaam}</td>
            <td>${stud.geg.geslacht}</td>
            <td>${stud.campus.campus_naam} (${stud.campus.campus_id})</td>
            <td class="text-right">€ ${stud.openstaand.toLocaleString("nl-BE")}</td>
            </tr>
          `;
    });
    tbodyEl.innerHTML = tableData;
}

// ********* FILTER CHECKBOX *************
const filterStuds = () => {
        let campusData = [];

        // We kijken of de checkbox aangevinkt is
        const chkEl = frm.querySelector('input[name=inlineChkCampus1]:checked');
        // console.log(elChk);

        if (chkEl !== null) {
            const chkVal = chkEl.value;
            // We filteren op de waarde van de checkbox
            campusData = workingData.filter(stud => stud.campus.campus_id == chkVal);
            // console.log("cdata: ", campusData);
            return campusData;
        } else {
            return workingData;
        }
    } // End filterData

// ********* TOON SCHULD *************
const openstaandStud = () => {

    // console.log("wdataSchuld: ", workingData);
    if (workingData.length > 0) {
        totOpen = workingData.reduce((studA, studB) => ({
            openstaand: studA.openstaand + studB.openstaand
        }));
        alert(`Er staat nog een bedrag open van: ${totOpen.openstaand.toLocaleString("nl-BE")} EUR.`);
    } else {
        alert(`Geen student(en) geselecteerd.`);
    }
};

// We koppelen de events aan de selectors
document.querySelector("#inlineChkCampus1").addEventListener('change', getData());
document.querySelector("#buttonZoeken").addEventListener('click', getData());
document.querySelector("#buttonOpenstaand").addEventListener('click', openstaandStud());