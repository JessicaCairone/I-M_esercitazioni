function renderHouses(){
    let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
    
    let housesRender = '';
    
    for( let [index, item] of catalogue.entries()){
        housesRender += `
        <tr>
            <td class="text-warning">${index + 1}</td>
            <td class="text-warning">${item.nome}</td>
            <td class="text-warning">${item.descrizione}</td> 
            <td class="text-warning"><img src=${item.logoCasata} alt="house" class="house"/></td>
            <td><button type="button" class="btn btn-danger text-dark" onclick="deleteHouse(${index})">Elimina</button></td>
            <td><button type="button" class="btn btn-warning text-dark" onclick="updateHouse(${index})">Modifica</button></td>
            </tr>
        `
        document.getElementById('houses-table').innerHTML = housesRender;   
    }
    }
    
    
    function updateHouse(indice){
     $('#house-modal').modal('show'); 
     $('#btn-save').data('id', indice);  
    let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
    
    for(let [index, item] of catalogue.entries()){
        if(indice == index) {
            document.getElementById('nom').value = item.nome;
            document.getElementById('desc').value = item.descrizione;
            document.getElementById('logo-cas').value = item.logoCasata;
        
    
        }
    }
    }
    
    function saveHouse(varBtn) {
       let btnSave = $(varBtn).data('id');
        let varNom = document.getElementById('nom').value;
        let varDesc = document.getElementById('desc').value;
        let varLogo = document.getElementById('logo-cas').value;
      
       
        let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
       for ( let [index, item] of catalogue.entries()){
        if(index == btnSave){
            item.nome = varNom;
            item.descrizione = varDesc;
            item.logoCasata = varLogo; 
           
    
            localStorage.setItem('houses', JSON.stringify(catalogue));
            renderWands();
           $('#houses-modal').modal('hide');
            return;   
        }
       } 
    
    }
    
    
    function deleteHouse(idx){
        let catalogue = localStorage.getItem('houses') != null ? JSON.parse(localStorage.getItem('houses')) : [];
        catalogue.splice(idx, 1);
        localStorage.setItem('houses', JSON.stringify(catalogue));
        renderHouses();
    } 
    
    renderHouses();