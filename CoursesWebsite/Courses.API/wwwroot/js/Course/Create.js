var formReady = false;
function FirstPanelDone() {
    FirstPanelToSummary();
    document.getElementById("FirstPanel").style.transform = `translateX(-200%)`;
    if (formReady) {
        document.getElementById("Summary").style.transform = `translateX(0)`;
    } else {
        document.getElementById("SecondPanel").style.transform = 'translateX(0)';
    }   
}
function ReturnToFirstPanel(isFromSummary) {
    
    if (isFromSummary == 'true') {
        document.getElementById("FirstPanel").style.transform = `translateX(0)`;
        document.getElementById("Summary").style.transform = `translateX(-200%)`;
    } else {
        document.getElementById("FirstPanel").style.transform = `translateX(0)`;
        document.getElementById("SecondPanel").style.transform = 'translateX(250%)';     
    }
}
function SecondPanelDone() {
    SecondPanelToSummary();
    document.getElementById("SecondPanel").style.transform = `translateX(-200%)`;
    if (formReady) {
        document.getElementById("Summary").style.transform = `translateX(0)`;
    } else {
        document.getElementById("LastPanel").style.transform = `translateX(0)`;
    }
    
    
}
function ReturnToSecondPanel(isFromSummary) {
    document.getElementById("SecondPanel").style.transform = 'translateX(0)';
    if (isFromSummary == 'true') {
        document.getElementById("Summary").style.transform = `translateX(-200%)`;
    } else {
        document.getElementById("LastPanel").style.transform = `translateX(250%)`;       
    }    
}
function ReturnToLastPanel() {
    document.getElementById("LastPanel").style.transform = `translateX(0)`;
    document.getElementById("Summary").style.transform = `translateX(-200%)`;
}
function GoToSummary() {
    formReady = true;
    LastPanelToSummary();
    document.getElementById("LastPanel").style.transform = `translateX(-200%)`;
    document.getElementById("Summary").style.transform = `translateX(0)`;
    lastPanel = true;
}
document.getElementById("Picture").addEventListener('change', AddImage);
function AddImage() {
    if (!this.files || !this.files[0]) return;
    const reader = new FileReader();

    reader.addEventListener("load", function (evt) {
        document.getElementById("PictureView").style.backgroundImage = `url('${evt.target.result}')`;
        document.getElementById("PictureView").style.backgroundRepeat = `no-repeat`;
        document.getElementById("PictureView").style.backgroundPosition = `center`;
        document.getElementById("PictureView").style.backgroundSize = `cover`;
        document.getElementById("PictureView").style.backdropFilter = 'blur(0)';

    });
    reader.readAsDataURL(this.files[0]);
}
function FirstPanelToSummary() {
    document.getElementById("SummaryTitle").innerHTML = document.getElementById("Title").value;
    document.getElementById("SummaryDescription").innerHTML = document.getElementById("Description").value;
}
function SecondPanelToSummary() {
    document.getElementById("SummaryPicture").style.backgroundImage = document.getElementById("PictureView").style.backgroundImage;
    document.getElementById("SummaryPicture").style.backgroundRepeat = document.getElementById("PictureView").style.backgroundRepeat;
    document.getElementById("SummaryPicture").style.backgroundPosition = document.getElementById("PictureView").style.backgroundPosition;
    document.getElementById("SummaryPicture").style.backgroundSize = document.getElementById("PictureView").style.backgroundSize;
}
function LastPanelToSummary() {
    document.getElementById("SummaryPrice").innerHTML = document.getElementById("Price").value + " zł";
    document.getElementById("SummaryAuthor").innerHTML = document.getElementById("Author").value;
}