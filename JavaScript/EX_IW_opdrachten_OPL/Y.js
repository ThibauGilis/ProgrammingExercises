let list = document.querySelector("#starWarsPeopleList")


fetch("https://swapi.dev/api/people/")
    .then((response) => {
        if (response.ok) {
            return response.json();
        } else {
            return Promise.reject({
                status: response.status,
                statusText: response.statusText,
              })
        }
    })
    .then((data) => {
        let workingData = data.results;
        workingData.forEach(data => {
            let li = document.createElement("li")
            let p = document.createElement("p")
            li.classList.add("list-group-item")
            p.textContent = `${data.name} (${data.gender})`
            li.appendChild(p)
            list.appendChild(li)
        });
    })
    .catch((err) => console.log(err))

        //-------------------------------------------------------------------------------------------

    const starWarsPeopleList = document.querySelector("#starWarsPeopleList")
    const divRes = document.querySelector("#divErr")

    fetch("https://swapi.dev/api/peoplee/")
      .then((response) => {
        if (response.ok) {
          return response.json()
        } else {
          return Promise.reject({
            status: response.status,
            statusText: response.statusText,
          })
        }
      })
      .then((json) => {
        let people = json.results
        let res = ""

        for (p of people) {
          let listItem = document.createElement("li")
          listItem.setAttribute("class", "list-group-item")

          res = 
                        <p class="m-0">
                            ${p.name} ${
            p.gender == "n/a" ? "" : "(" + p.gender + ")"
          }                
                        </p>
                      
          listItem.innerHTML = res
          starWarsPeopleList.appendChild(listItem)
        }
      })
      .catch((err) => (divRes.innerHTML = err.statusText))