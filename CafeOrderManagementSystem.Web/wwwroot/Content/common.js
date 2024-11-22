function OnBoxConfirm({
    title,
    text,
    confirmButtonText,
    onConfirm, 
    successTitle,
    successText
}) {
    Swal.fire({
        title: title,
        text: text,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: confirmButtonText,
    }).then((result) => {
        if (result.isConfirmed) {
            if (onConfirm && typeof onConfirm === "function") {
                onConfirm(); 
                
            }
        }
    });
}
function successToast(message) {
    showToast('İşlem Başarılı:' + message, 'success');
}
function errorToast(message) {
    showToast('İşlem Hatalı:'+message, 'error');
}
function showToast(message = "Bu bir mesajdır!", type = "info") {
    const backgroundColors = {
        error: "#f44336", 
        info: "#2196f3",  
        success: "#4caf50",
        warning: "#ff9800"
    };

    const backgroundColor = backgroundColors[type] || "#333"; 
    const toast = document.createElement("div");
    toast.innerText = message;
    toast.style.position = "fixed";
    toast.style.top = "20px";
    toast.style.right = "20px";
    toast.style.backgroundColor = backgroundColor; 
    toast.style.color = "#fff";
    toast.style.padding = "10px 20px";
    toast.style.borderRadius = "5px";
    toast.style.boxShadow = "0px 4px 6px rgba(0, 0, 0, 0.1)";
    toast.style.fontSize = "14px";
    toast.style.zIndex = "9999";
    toast.style.opacity = "0";
    toast.style.transition = "opacity 0.5s ease-in-out";
    document.body.appendChild(toast);
    setTimeout(() => {
        toast.style.opacity = "1";
    }, 10);

    setTimeout(() => {
        toast.style.opacity = "0"; 
        setTimeout(() => {
            toast.remove();
        }, 500); 
    }, 3000);
}


    