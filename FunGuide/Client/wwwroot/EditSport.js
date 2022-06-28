export function EditSport(sportNameId, changeSportNameId, buttonId, changeButtonId) {
  

    document.getElementById(sportNameId).style.display = "none";
    document.getElementById(changeSportNameId).style.display = "inline";
    document.getElementById(buttonId).style.display = "none";
    document.getElementById(changeButtonId).style.display = "inline";
}
export function Open(filter) {
    document.getElementById(filter).style.display = "table-row";

}
export function Close(filter) {
    document.getElementById(filter).style.display = "none";

}