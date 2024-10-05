function wandInsert() {
let catalogue = localStorage.getItem('wands') != null ? JSON.parse(localStorage.getItem('wands')) : [];

let cod = Math.floor(Math.random() * 90000) + 10000;
let mat = document.getElementById('mat').value;
let nuc = document.getElementById('nuc').value;
let lung= document.getElementById('lung').value;
let res = document.getElementById('res').value;
let mag = document.getElementById('mago').value;
let cas = document.getElementById('cas').value;
let img = document.getElementById('img').value;
let matField = document.getElementById('mat');
let nucField = document.getElementById('nuc');
let lungField = document.getElementById('lung');
let resField = document.getElementById('res');
let magField = document.getElementById('mago');
let imgField = document.getElementById('img');

    let warningMat = document.getElementById('warning-mat');
    let warningNuc = document.getElementById('warning-nuc');
    let warningLung = document.getElementById('warning-lung');
    let warningRes = document.getElementById('warning-res');
    let warningMag = document.getElementById('warning-mag');
    let warningImg = document.getElementById('warning-img');
    matField.style.backgroundColor = '';
    nucField.style.backgroundColor = '';
    lungField.style.backgroundColor = '';
    resField.style.backgroundColor = '';
    magField.style.backgroundColor = '';
    imgField.style.backgroundColor = '';
    warningMat.innerText = '';
    warningNuc.innerText = '';
    warningLung.innerText = '';
    warningRes.innerText = ''; 
    warningMag.innerText = ''; 
    warningImg.innerText = ''; 


    let inputValue;

    if (mat == '') 
        inputValue = 'mat'; 
     else if (nuc == '') 
        inputValue = 'nuc';
    else if (lung == '') 
        inputValue = 'lung'; 
    else if (res == '') 
        inputValue = 'res'; 
    else if (mag == '') 
        inputValue = 'mag'; 
    else if (img == '') 
        inputValue = 'img'; 
    

if(mat != '' && mat != '' && nuc != '' && lung != '' && res != '' && mag != '' && img != ''){
    let wand = {
        codice: cod,
        materiale: mat,
        nucleo: nuc,
        lunghezza: lung,
        resistenza: res,
        mago: mag,
        casata: cas,
        image: img
    }
    
    catalogue.push(wand);
     
    localStorage.setItem('wands', JSON.stringify(catalogue));
    
    document.getElementById('cod').value = '';
    document.getElementById('mat').value = '';
    document.getElementById('nuc').value = '';
    document.getElementById('lung').value = '';
    document.getElementById('res').value = '';
    document.getElementById('mago').value = '';
    document.getElementById('cas').value = '';
    document.getElementById('img').value = '';
    
    location.href="wands.html";
}else {
    //NON FUNZIONA COME PER DELLE CASATE, NON HO INDIVIDUATO L'ERRORE
    switch(inputValue){
        case 'mat':
            matField.style.backgroundColor = 'rgb(237, 59, 59)'; 
        warningMat.innerText = 'Compila questo campo';
            break;
            case 'nuc':
            nucField.style.backgroundColor = 'rgb(237, 59, 59)';
         warningNuc.innerText = 'Compila questo campo';
            break;
            case 'lung':
            lungField.style.backgroundColor = 'rgb(237, 59, 59)';
         warningLung.innerText = 'Compila questo campo';
            break; 
            case 'res':
                resField.style.backgroundColor = 'rgb(237, 59, 59)'; 
            warningRes.innerText = 'Compila questo campo';
                break;
                case 'mag':
                magField.style.backgroundColor = 'rgb(237, 59, 59)';
             warningMag.innerText = 'Compila questo campo';
                break;
            default:
               imgField.style.backgroundColor = 'rgb(237, 59, 59)';
             warningImg.innerText = 'Compila questo campo';
                break; 
    }
}

}

function addOption() {
    let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
    let selectHouse = document.getElementById('cas');

    catalogue.forEach(house => {
        let newOption = document.createElement('option');
        newOption.innerHTML = house.nome; 
        newOption.value = house.nome; 
        selectHouse.appendChild(newOption);
    });
}

window.onload = addOption;