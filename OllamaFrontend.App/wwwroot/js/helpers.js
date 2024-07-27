function setTheme(darkmode){
    let theme = darkmode ? "dark" : "light";
    document.getElementsByTagName("html")[0].setAttribute("data-bs-theme", theme)
}
function prefersDarkMode(){
    return window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
}

if (prefersDarkMode()) {
    document.getElementsByTagName("html")[0].setAttribute("data-bs-theme", "dark")
}
window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
    const newColorScheme = e.matches ? "dark" : "light";
    document.getElementsByTagName("html")[0].setAttribute("data-bs-theme", newColorScheme)
});