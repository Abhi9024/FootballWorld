import { Component,OnInit } from '@angular/core';
import { IClub } from '../../interface/IClub';
import { FootballService } from '../../service/football.service';
import {  FormGroup, FormBuilder, Validators } from '@angular/forms';
 
@Component({
    selector: 'football',
    templateUrl: './football.component.html',
    providers: [FootballService]
})
export class FootballComponent {

    clubs: IClub[];
    clubsForm: FormGroup;
    IsAddClubEnabled: boolean;

    club: IClub = {
        clubName: '',
        clubDescription: '',
        championsLeagueTitle:0,
        leagueName: '',
        leagueTitles: 0,
        clubWorth: '',
        country: '',
        ranking: 0,
        state: '',
        defensive: 0,
        offensive:0
    };

    constructor(private footBallService: FootballService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.getChampionsLeagueClubs();
        this.buildForm();
    };

    getChampionsLeagueClubs() {
        this.footBallService.getChampionsLeagueClubs()
            .subscribe(result => { this.clubs = result }, (err) => console.log(err));
    };

    buildForm() {
        this.clubsForm = this.formBuilder.group({
            clubName: [this.club.clubName, Validators.required],
            clubDescription: [this.club.clubDescription, Validators.required],
            championsLeagueTitle: [this.club.championsLeagueTitle, Validators.required],
            leagueName: [this.club.leagueName, Validators.required],
            leagueTitles: [this.club.leagueTitles, Validators.required],
            clubWorth: [this.club.clubWorth, Validators.required],
            country: [this.club.country, Validators.required],
            ranking: [this.club.ranking, Validators.required],
            state: [this.club.state, Validators.required]
        });
    };

    toggleAddClub(): void {
        this.IsAddClubEnabled = (this.IsAddClubEnabled) ? false : true;
    };

    public doughnutChartLabels: string[] = ['Defensive', 'Offensive'];
    public doughnutChartType: string = 'pie';

    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

}