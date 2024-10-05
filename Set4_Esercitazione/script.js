function renderWands(){
let catalogue = localStorage.getItem('wands') != null ? JSON.parse(localStorage.getItem('wands')) : [];

let wandsRender = '';

for( let [index, item] of catalogue.entries()){
    wandsRender += `
    <tr>
        <td class="text-warning">${index + 1}</td>
        <td class="text-warning">${item.codice}</td>
        <td class="text-warning">${item.materiale}</td>
        <td class="text-warning">${item.nucleo}</td>
        <td class="text-warning">${item.lunghezza}</td>
        <td class="text-warning">${item.resistenza}</td>
        <td class="text-warning">${item.mago}</td>
        <td class="text-warning">${item.casata}</td>
        <td class="text-warning"><img src=${item.image} alt="wand" class="wand"/></td>
        <td><button type="button" class="btn btn-danger text-dark" onclick="deleteWand(${index})">Elimina</button></td>
        <td><button type="button" class="btn btn-warning text-dark" onclick="updateWand(${index})">Modifica</button></td>
        </tr>
    `
  window.onload = addOption;
    document.getElementById('table').innerHTML = wandsRender;   
}
}


/*catalogue.forEach((item) => {
    wandsRender += `
    <tr>
        <td>${catalogue[i]}</td>
        <td>${item.codice}</td>
        <td>${item.materiale}</td>
        <td>${item.nucleo}</td>
        <td>${item.lunghezza}</td>
        <td>${item.resistenza}</td>
        <td>${item.mago}</td>
        <td>${item.casata}</td>
        <td>${item.image}</td>
        <td><button type="button" class="btn btn-danger text-dark" onclick="deleteWand(${index})">Elimina</button></td>
    </tr>
    `
    document.getElementById('table').innerHTML = wandsRender;   
});

*/


function updateWand(indice){
 $('#update-modal').modal('show'); 
 $('#btn-save').data('id', indice);  
let catalogue = localStorage.getItem('wands') != null ? JSON.parse(localStorage.getItem('wands')) : [];

for(let [index, item] of catalogue.entries()){
    if(indice == index) {
        document.getElementById('cod').value = item.codice;
        document.getElementById('mat').value = item.materiale;
        document.getElementById('nuc').value = item.nucleo;
        document.getElementById('lung').value = item.lunghezza;
        document.getElementById('res').value = item.resistenza;
        document.getElementById('mago').value = item.mago;
        document.getElementById('cas').value = item.casata;
        document.getElementById('img').value = item.image;

    }
}
}

function saveUpdate(varBtn) {
   let btnSave = $(varBtn).data('id');
    let varCod = document.getElementById('cod').value;
    let varMat = document.getElementById('mat').value;
    let varNuc = document.getElementById('nuc').value;
    let varLung = document.getElementById('lung').value;
   let varRes = document.getElementById('res').value;
   let varMag = document.getElementById('mago').value;
    let varCas= document.getElementById('cas').value;
    let varImg = document.getElementById('img').value;
   
    let catalogue = localStorage.getItem('wands') != null ? JSON.parse(localStorage.getItem('wands')) : [];
   for ( let [index, item] of catalogue.entries()){
    if(index == btnSave){
        item.codice = varCod;
        item.materiale = varMat;
        item.nucleo = varNuc; 
        item.lunghezza = varLung; 
        item.resistenza = varRes; 
        item.mago = varMag; 
        item.casata = varCas; 
        item.image= varImg; 

        localStorage.setItem('wands', JSON.stringify(catalogue));
        renderWands();
       $('#update-modal').modal('hide');
        return;   
    }
   } 

}


function deleteWand(idx){
    let catalogue = localStorage.getItem('wands') != null ? JSON.parse(localStorage.getItem('wands')) : [];
    catalogue.splice(idx, 1);
    localStorage.setItem('wands', JSON.stringify(catalogue));
    renderWands();
} 

renderWands();