let hardCodedJson = [
    {
      id: '27495ef2-f63f-43f0-a410-69d649ba62a2',
      title: 'HIT ME HARD AND SOFT',
      artist: 'Billie Eilish',
      price: 34.99,
      type: '12 Inch Vinyl',
      image: '/data/images/HitMeHardAndSoft.webp',
      releaseDate: '2024-05-17',
    },
    {
      id: '96a9c07d-ed24-4960-907c-11d0b2c0d47c',
      title: 'Espresso',
      artist: 'Sabrina Carpenter',
      price: 14.99,
      type: '7 Inch Vinyl',
      image: '/data/images/Espresso.webp',
      releaseDate: '2024-06-07',
    },
    {
      id: '622a7a3f-96de-41b2-a0ca-b60cd6afa480',
      title: 'The Tortured Poets Department + Bonus Track "The Manuscript"',
      artist: 'Taylor Swift',
      price: 38.99,
      type: '12 Inch Vinyl',
      image: '/data/images/TTPD_Manuscript.webp',
      releaseDate: '2024-04-19',
    },
    {
      id: 'd1584fd1-ab7b-439e-95d6-dbc4dae5d32b',
      title: 'The Tortured Poets Department + Bonus Track "The Black Dog"',
      artist: 'Taylor Swift',
      price: 29.99,
      type: 'CD',
      image: '/data/images/TTPD_Black_Dog.webp',
      releaseDate: '2024-04-19',
    },
    {
      id: '7213a79b-b55e-44ac-a6d3-cd978d11ea3c',
      title: 'Stick Season',
      artist: 'Noah Kahan',
      price: 19.99,
      type: 'CD',
      image: '/data/images/StickSeason.webp',
      releaseDate: '2024-04-19',
    },
    {
      id: 'd3143c7f-1d3c-4992-808e-e2afa0e02fe3',
      title: 'GUTS',
      artist: 'Olivia Rodrigo',
      price: 11.99,
      type: 'Cassette',
      image: '/data/images/GUTS.webp',
      releaseDate: '2023-09-08',
    },
    {
      id: '12cdaab1-dbbd-45d7-b1a3-cf4d5b50b5d1',
      title: 'Good Riddance',
      artist: 'Gracie Abrams',
      price: 39.99,
      type: '12 Inch Vinyl',
      image: '/data/images/GoodRiddance.webp',
      releaseDate: '2023-06-16',
    },
    {
      id: '8fcecfee-d958-494e-9c51-78ad48e0bf23',
      title: 'Did you know that there\'s a tunnel under Ocean Blvd',
      artist: 'Lana Del Rey',
      price: 11.99,
      type: 'Cassette',
      image: '/data/images/OCEAN_BLVD.webp',
      releaseDate: '2023-03-24',
    },
    {
      id: '446abf0d-89a0-40d5-980b-aab94a14dc4b',
      title: 'ABBA Studio Albums',
      artist: 'ABBA',
      price: 49.99,
      type: 'CD',
      image: '/data/images/ABBA.webp',
      releaseDate: '2022-05-27',
    },
    {
      id: 'd9329c51-716c-41a1-be79-6ccffba8c6f0',
      title: 'Deeper Well Cassette',
      artist: 'Kacey Musgraves',
      price: 14.99,
      type: 'Cassette',
      image: '/data/images/DeeperWell.webp',
      releaseDate: '2024-03-15',
    },
  ]
  ;


let fetchData = async () => {
    const jsonUrl = "/data/music.json";

    return fetch(jsonUrl)
            .then(response => {
                if (response.ok){
                    return response.json();
                } else {
                    return Promise.reject({
                        status: response.status,
                        statusText: response.statusText,
                      })
                }
            })
            .catch((err) => {
                console.log(err); 
                let fecthResult = document.getElementById('fetch-foutmelding');
                fecthResult.classList.remove('d-none')
            })
}

let renderAlbums = (albums, shoppingcart, titleFilter, typeFilter) => {
    let albumsList = document.getElementById('albums')
    albums.forEach(album => {
        if (titleFilter){
            if (album.title != titleFilter){
                return;
            }
        }
        if (typeFilter){
            if (album.type != typeFilter){
                return;
            }
        }
        let table = document.createElement('table');
        table.setAttribute('id', album.id);
        table.setAttribute('class', 'table')
        table.innerHTML = `<tr><td><img src="${album.image}"></td> <td>${album.title}</td> <td>${album.artist}</td> <td>${album.type}</td> <td>${album.price}</td> <td><button class="btn btn-info" id="${album.id}">+</button></td></tr>`;
        albumsList.appendChild(table);
        document.getElementById(album.id).addEventListener("click", (e) => {
            const id = e.target.id;
            const album = albums.find(album => album.id == id)
            const naam = album.title;
            const prijs = album.price;

            shoppingcart.addAlbum(id, naam, prijs)
        })
    }); 
}

//-------------------------------------------------------------------------

class ShoppingCart {
    constructor() {
        this.items = [];
    }

    addAlbum(id, naam, prijs) {
        console.log(naam + " " + prijs)
        const index = this.items.findIndex(item => item.id == id)
        if ( index == -1){
            this.items.push({id, naam, prijs, aantal: 1})
        } else {
            this.items[index].aantal++;
        }
        console.log(this.items)
        this.emptyCart();
        this.renderItems();
    }

    renderItems() {
        let winkelkar = document.getElementById('shopping-cart-items');
        this.items.forEach(item => {
            let li = document.createElement('li');
            li.textContent = `${item.naam} ${item.prijs} ${item.aantal == 1 ? "": "x" + item.aantal}`
            console.log('--------------')
            console.log(li);
            winkelkar.appendChild(li)

            let totaalPrijs = 0;
             this.items.forEach(item => totaalPrijs += item.prijs * item.aantal)
            document.getElementById('shopping-cart-total').innerHTML = totaalPrijs;
        })
    }

    emptyCart() {
        let winkelkar = document.getElementById('shopping-cart-items');
        winkelkar.textContent = '';
    }
}

let start = async () => {

    let shoppingcart = new ShoppingCart();
    let albums = []

    document.getElementById('clear-cart').addEventListener("click", () => {
        shoppingcart.emptyCart();
        shoppingcart.items = [];
    })

    document.getElementById('filter-btn').addEventListener("click", () => {
        let titleValue = document.getElementById('title-filter').value
        let typeValue = document.getElementById('type-filter').value

        let albumlijst = document.getElementById('albums');
        albumlijst.textContent = '';

        // werkt niet
    
        renderAlbums(albums, shoppingcart, titleValue, typeValue);
    })

    // albums = hardCodedJson;
    albums = await fetchData();
    if (albums) {
        renderAlbums(albums, shoppingcart);
    }

}

start();




