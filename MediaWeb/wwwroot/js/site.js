function newFilmInput() {
    var inputList = document.getElementsByName("Regi");
    inputList.forEach(function (element) {
        element.removeAttribute("onchange");
    })
    var input = document.createElement("input");
    input.type = "text";
    input.name = "Regi";
    input.setAttribute("onchange", "newFilmInput()");
    document.getElementById("RegiInput").appendChild(input);
}
function favToggle() {
    document.getElementById("FavForm").submit();
}
function gezienSelect() {
    document.getElementById("GezienForm").submit();
}
function muziekGenreSelect(){
    document.getElementById("GenreForm").submit();
}