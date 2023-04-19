
function showAlert({ message }) {
    let alert = document.createElement("div");
    alert.className = "alert alert-success alert-container alert-dismissible";
    alert.innerHTML = message;
    document.body.appendChild(alert);
    
    setTimeout(() => {
        document.body.removeChild(alert);
    }
    , 3000);
    
    
}