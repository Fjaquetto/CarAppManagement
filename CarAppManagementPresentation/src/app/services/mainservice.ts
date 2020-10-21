export class MainService {
    
  urlServer: string = "https://webapi.carappmanagement.com/";

  formatarData(date) {
    debugger;

    if (!date)
      return null;

    if (date !== "") {
      var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2)
        month = '0' + month;
      if (day.length < 2)
        day = '0' + day;

      return [year, month, day].join('-');
    }
    else {
      return null;
    }
  }

  formatarDataTabela(date) {

    if (!date)
      return null;

    if (date !== "") {
      var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

      if (month.length < 2)
        month = '0' + month;
      if (day.length < 2)
        day = '0' + day;

      return [day, month, year].join('/');
    }
    else {
      return null;
    }
  }

  formatarBool(data) {
    if (data == true)
      return "Sim"

    if (data == false)
      return "Não"
  }

  formatarDataModal(data) {
    if (!data) {
      return null;
    }
    else {
      return new Date(data);
    }
  }
}