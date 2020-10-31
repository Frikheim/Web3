import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Spørsmål } from "../Spørsmål";

@Component({
  templateUrl: "faq.html"
})
export class Faq {
  alleSpørsmål: Array<Spørsmål>;
  //kategorier med spørsmål
  innloggingSpørsmål: Array<Spørsmål>;
  visInnlogging: Array<Boolean>;
  billettSpørsmål: Array<Spørsmål>;
  visBillett: Array<Boolean>;
  ruteSpørsmål: Array<Spørsmål>;
  visRute: Array<Boolean>;
  andreSpørsmål: Array<Spørsmål>;
  visAndre: Array<Boolean>;
  
  laster: boolean;


  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleKunder();
    this.innloggingSpørsmål = new Array<Spørsmål>();
    this.visInnlogging = new Array<Boolean>();
    this.billettSpørsmål = new Array<Spørsmål>();
    this.visBillett = new Array<Boolean>();
    this.ruteSpørsmål = new Array<Spørsmål>();
    this.visRute = new Array<Boolean>();
    this.andreSpørsmål = new Array<Spørsmål>();
    this.visAndre = new Array<Boolean>();
    this.sorter();
  }

  hentAlleKunder() {
    this.http.get<Spørsmål[]>("api/spørsmål/")
      .subscribe(spørsmålene => {
        this.alleSpørsmål = spørsmålene;
        
        this.laster = false;
      },
        error => console.log(error)
      );
  };

  sorter() {
    this.alleSpørsmål.forEach(function (spørsmål) {
      switch (spørsmål.kategori) {
        case "Innlogging": {
          this.innloggingSpørsmål.push(spørsmål);
          this.visInnlogging.push(false);
          break;
        }
        case "Rute": {
          this.ruteSpørsmål.push(spørsmål);
          this.visRute.push(false);
          break;
        }
        case "Billett": {
          this.billettSpørsmål.push(spørsmål);
          this.visBillett.push(false);
          break;
        }
        case "Annet": {
          this.andreSpørsmål.push(spørsmål);
          this.visAndre.push(false);
          break;
        }
      }
    })
  };

  visInnloggingSvar(index: number) {
    if (this.visInnlogging[index] == false) {
      this.visInnlogging[index] = true;
    }
    else {
      this.visInnlogging[index] = false;
    }
  };

  visRuteSvar(index: number) {
    if (this.visRute[index] == false) {
      this.visRute[index] = true;
    }
    else {
      this.visRute[index] = false;
    }
  };

  visBillettSvar(index: number) {
    if (this.visBillett[index] == false) {
      this.visBillett[index] = true;
    }
    else {
      this.visBillett[index] = false;
    }
  };

  visAndreSvar(index: number) {
    if (this.visAndre[index] == false) {
      this.visAndre[index] = true;
    }
    else {
      this.visAndre[index] = false;
    }
  };

  
}
