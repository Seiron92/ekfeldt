var filter = document.getElementById("filter"); // filter button
var typesOutput = document.getElementById("typesOutput"); // separate output for "home type"
var district = document.getElementById("District");  // counties
var minRoom = document.getElementById("minRoom");
var maxRoom = document.getElementById("maxRoom");
var minPrice = document.getElementById("minPrice");
var maxPrice = document.getElementById("maxPrice");
var minroomput = document.getElementById("minroomput");


var listnings = document.getElementById("listnings"); // listnings output for all or specific homes

function homes(list) {

    filter.onclick = function () {
        listnings.innerHTML = ""; // make listnings empty

        for (var i = 0; i < list.length; i++) {
            var bids = list[i].bidding;
            if (bids == true) {
                bids = "<div class='bidding'>Budgiving pågår</div>";
            } else {
                bids = "";
            }
            var price = list[i].price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
            if (list[i].deleted != true && list[i].type == typesOutput.value && district.value == "" && list[i].price >= minPrice.value && list[i].price <= maxPrice.value && list[i].room >= minRoom.value && list[i].room <= maxRoom.value) {
              
      

                listnings.innerHTML += `
            <div class="homesSection margin">
                <a target="_blank" href="/Home/Details/${list[i].homeId}?BrokerId=${list[i].brokerId}">
     
                       <img class="imagesInner" src="/images/${list[i].imageAddress}" alt="Bild på hus/bostadsrätt" /><div class="bids">${bids}</div><div class="inner">
                        <h2>${list[i].city}</h2><h3>${list[i].street}</h3><ul>
                            <li> <i class="fas fa-home"></i> ${list[i].type}</li>
                            <li>
                                <i class="fas fa-ruler-combined"></i> ${list[i].livingArea}
                     <p class="inline"> + </p> ${list[i].biArea}kvm
                                </li>
                            <li><i class="fas fa-tree"></i> ${list[i].gardenArea}kvm</li>
                            <li><i class="fas fa-expand"></i> ${list[i].room} rum</li>
                        </ul><h3> ${price} kr</h3>
                    </div>
                </a>
            </div>`;
              
       
            }
            else if (list[i].deleted != true && typesOutput.value == "" && district.value == list[i].county && list[i].price >= minPrice.value && list[i].price <= maxPrice.value && list[i].room >= minRoom.value && list[i].room <= maxRoom.value) {
    
                listnings.innerHTML += `
             <div class="homesSection margin">
                <a target="_blank" href="/Home/Details/${list[i].homeId}?BrokerId=${list[i].brokerId}">
     
                       <img class="imagesInner" src="/images/${list[i].imageAddress}" alt="Bild på hus/bostadsrätt" /><div class="bids">${bids}</div><div class="inner">
                        <h2>${list[i].city}</h2><h3>${list[i].street}</h3><ul>
                            <li> <i class="fas fa-home"></i> ${list[i].type}</li>
                            <li>
                                <i class="fas fa-ruler-combined"></i> ${list[i].livingArea}
                     <p class="inline"> + </p> ${list[i].biArea}kvm
                                </li>
                            <li><i class="fas fa-tree"></i> ${list[i].gardenArea}kvm</li>
                            <li><i class="fas fa-expand"></i> ${list[i].room} rum</li>
                       </ul><h3> ${price} kr</h3>
                    </div>
                </a>
            </div>`;
  

            }
            else if (list[i].deleted != true && list[i].type == typesOutput.value && list[i].county == district.value && list[i].price >= minPrice.value && list[i].price <= maxPrice.value && list[i].room >= minRoom.value && list[i].room <= maxRoom.value) {

                listnings.innerHTML += `
             <div class="homesSection margin">
                <a target="_blank" href="/Home/Details/${list[i].homeId}?BrokerId=${list[i].brokerId}">
     
                       <img class="imagesInner" src="/images/${list[i].imageAddress}" alt="Bild på hus/bostadsrätt" /><div class="bids">${bids}</div><div class="inner">
                       <h2>${list[i].city}</h2><h3>${list[i].street}</h3><ul>
                            <li> <i class="fas fa-home"></i> ${list[i].type}</li>
                            <li>
                                <i class="fas fa-ruler-combined"></i> ${list[i].livingArea}
                     <p class="inline"> + </p> ${list[i].biArea}kvm
                                </li>
                            <li><i class="fas fa-tree"></i> ${list[i].gardenArea}kvm</li>
                            <li><i class="fas fa-expand"></i> ${list[i].room} rum</li>
                       </ul><h3> ${price} kr</h3>
                    </div>
                </a>
            </div>`;
 
            }

            else if (list[i].deleted != true && typesOutput.value == "" && district.value == "" && list[i].price >= minPrice.value && list[i].price <= maxPrice.value && list[i].room >= minRoom.value && list[i].room <= maxRoom.value) {

                listnings.innerHTML += `
             <div class="homesSection margin">
                <a target="_blank" href="/Home/Details/${list[i].homeId}?BrokerId=${list[i].brokerId}">
     
                       <img class="imagesInner" src="/images/${list[i].imageAddress}" alt="Bild på hus/bostadsrätt" /><div class="bids">${bids}</div><div class="inner">
                        <h2>${list[i].city}</h2><h3>${list[i].street}</h3><ul>
                            <li> <i class="fas fa-home"></i> ${list[i].type}</li>
                            <li>
                                <i class="fas fa-ruler-combined"></i> ${list[i].livingArea}
                     <p class="inline"> + </p> ${list[i].biArea}kvm
                                </li>
                            <li><i class="fas fa-tree"></i> ${list[i].gardenArea}kvm</li>
                            <li><i class="fas fa-expand"></i> ${list[i].room} rum</li>
                        </ul><h3> ${price} kr</h3>
                    </div>
                </a>
            </div>`;

            }

 
        }
        if (listnings.innerHTML == "") {
            listnings.innerHTML += "<h2>Det finns inga bostäder som matchar sökkriterierna</h2>";
        }
    }
}

minRoom.onchange = function () {
    minroomout.innerHTML = minRoom.value;
}



    function loadContent() {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var display = JSON.parse(this.response);
                homes(display);
                 console.log(display)
            }
        };
        xhr.open('GET','https://ekfeldt.herokuapp.com/api/HomesApi/', true);
        xhr.send();
    }
    loadContent();


