
const titleName = document.querySelector(".titleName")
const firstName = sessionStorage.getItem("firstName")
titleName.textContent = `ברוכה הבאה ${firstName} מייד נצלול פנימה`

const extrctDataFromInput = () => {
    const userName = document.querySelector("#userName").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const password = document.querySelector("#password").value
    return { userName, firstName, lastName, password }
}

const createObjUser = (upDateValues) => {
    const id = Number(sessionStorage.getItem("id"))
    const userName = upDateValues.userName
    const firstName = upDateValues.firstName
    const lastName = upDateValues.lastName
    const password = upDateValues.password
    return { id, userName, firstName, lastName, password }
}

const updateStorage = (upDateValues) => {
    sessionStorage.setItem("userName", upDateValues.userName)
    sessionStorage.setItem("firstName", upDateValues.firstName)
    sessionStorage.setItem("lastName", upDateValues.lastName)
    sessionStorage.setItem("password", upDateValues.password)
    sessionStorage.setItem("id", fullUser.id)

}

async function upDate() {
    const upDateValues = extrctDataFromInput()
    const currenrtUser = createObjUser(upDateValues)
    try {
        const response = await fetch(
            `https://localhost:44360/api/Users/${currenrtUser.id}`,
            {
                method: `PUT`,
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(currenrtUser)
            }
        )
        if (!response.ok) {
            throw new Error(`HTTP error! status ${response.status}`);
        }
        else {
            const upDateValues = extrctDataFromInput()
            updateStorage(upDateValues)
            alert("המשתמש עודכן בהצלחה")
        }
    }
    catch (e) {
        alert(e)
    }
}
