import { Component,OnInit } from '@angular/core';
import { IClub } from '../../interface/IClub';
import { FootballService } from '../../service/football.service';
 
@Component({
    selector: 'football',
    templateUrl: './football.component.html',
    providers: [FootballService]
})
export class FootballComponent {

    clubs: IClub[];

    constructor(private footBallService: FootballService) { }

    ngOnInit() {
        this.getChampionsLeagueClubs();
    };

    getChampionsLeagueClubs() {
        this.footBallService.getChampionsLeagueClubs()
            .subscribe(result => { this.clubs = result }, (err) => console.log(err));
    }
}