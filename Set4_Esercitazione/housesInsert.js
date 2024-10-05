function houseInsert() {
    let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
    
    let nom = document.getElementById('nom').value;
    let desc = document.getElementById('desc').value;
    let logCas = document.getElementById('logo-cas').value;
    let nomField = document.getElementById('nom');
    let descField = document.getElementById('desc');
    let logCasField = document.getElementById('logo-cas');
    let warningNom = document.getElementById('warning-nom');
    let warningDesc = document.getElementById('warning-desc');
    let warningLog = document.getElementById('warning-log');
    nomField.style.backgroundColor = '';
    descField.style.backgroundColor = '';
    logCasField.style.backgroundColor = '';
    warningNom.innerText = '';
    warningDesc.innerText = '';
    warningLog.innerText = '';

    let inputValue;

    if (nom == '') {
        inputValue = 'nom'; 
    } else if (desc == '') {
        inputValue = 'desc';
    } else if (logCas == '') {
        inputValue = 'logCas'; 
    }

   if (nom != '' && desc != '' && logCas != ''){
    let house = {
        nome: nom,
        descrizione: desc,
        logoCasata: logCas
    }
    
    catalogue.push(house);

    localStorage.setItem('houses', JSON.stringify(catalogue));

    document.getElementById('nom').value = '';
    document.getElementById('desc').value = '';
    document.getElementById('logo-cas').value = '';

    location.href='houses.html';
   }
   else {
        switch(inputValue){
            case 'nom':
            nomField.style.backgroundColor = 'rgb(237, 59, 59)'; 
            nomField.style.  
        warningNom.innerText = 'Compila questo campo';
            break;
            case 'desc':
            descField.style.backgroundColor = 'rgb(237, 59, 59)';
         warningDesc.innerText = 'Compila questo campo';
            break;
            default:
            logCasField.style.backgroundColor = 'rgb(237, 59, 59)';
         warningLog.innerText = 'Compila questo campo';
            break; 
        }
   }
     }

    