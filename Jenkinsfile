node {
    def app

    stages {

        stage('build') {
            agent { 
                docker 'microsoft/aspnetcore-build:2.0' 
            }
            steps {
//                bat 'dotnet build' 
               sh 'dotnet build' 
            }
        }
        stage('test') {
            agent { 
                docker 'microsoft/aspnetcore-build:2.0' 
            }
            steps {
//                bat 'dotnet test one.test'
               sh 'dotnet test one.test'
            }
        }
        stage('containerize') {
            steps {
//                bat 'docker build -t one:{BUILD_NUMBER} one'
               // sh 'docker build -t one:{BUILD_NUMBER} one'
                app = docker.build("one")
                //sh 'echo "here"'
            }
        }
    }
}